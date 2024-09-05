using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Mapper;
using RetailCore.ServiceContracts;
using System.Security.Cryptography;

namespace RetailCore.Services
{
	public class UserService : IUserService
	{
		private const int SaltSize = 32; // Size of salt in bytes
		private const int HashSize = 32; // Size of hash in bytes
		private const int Iterations = 10000; // Number of PBKDF2 iterations

		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;

		public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
		{
			this._unitOfWork = unitOfWork;
			this._userRepository = userRepository;
		}

		public BusinessObjects.BusinessObjects.User AddUser(BusinessObjects.BusinessObjects.User user)
		{
			var saltAndHash = CreateHash(user.Password);

			var userEntity = user.ToEntityModel();
			if (userEntity != null)
			{
				userEntity.PasswordSalt = Convert.FromBase64String(saltAndHash.Salt);
				userEntity.PasswordHash = Convert.FromBase64String(saltAndHash.Hash);
				this._userRepository.Add(userEntity);
				this._unitOfWork.Commit();
			}
			return user;
		}

		public BusinessObjects.BusinessObjects.User GetAdminUser()
		{
			var adminUserEntity = this._userRepository.Get(x => x.Username == "sa");
			if (adminUserEntity == null)
				return null;
			else
				return adminUserEntity?.ToBusinessObject();
		}

		public IEnumerable<BusinessObjects.BusinessObjects.User> GetUsers()
		{
			IList<BusinessObjects.BusinessObjects.User> users = new List<BusinessObjects.BusinessObjects.User>();

			foreach (var item in this._userRepository.GetAll())
			{
				users.Add(item.ToBusinessObject());
			}

			return users.AsEnumerable();
		}

		public int GetUserCount()
		{
			return this._userRepository.GetAll().Count();
		}

		public BusinessObjects.BusinessObjects.User VerifyUser(string username, string password)
		{
			var existingUser = _userRepository.Get(x => x.Username == username);
			if (existingUser != null && VerifyPassword(password, Convert.ToBase64String(existingUser.PasswordSalt), Convert.ToBase64String(existingUser.PasswordHash)))
			{
				return existingUser.ToBusinessObject();
			}

			return null;
		}

		public BusinessObjects.BusinessObjects.User GetUserById(Guid currentUser)
		{
			var userEntity = this._userRepository.LoadUserData(currentUser);
			if (userEntity != null)
			{
				var user = userEntity.ToBusinessObject();
				if (user != null)
				{
					user.Role = userEntity.Role?.ToBusinessObject();
					user.CreatedByNavigation = userEntity.CreatedByNavigation?.ToBusinessObject();
					user.ModifiedByNavigation = userEntity.ModifiedByNavigation?.ToBusinessObject();

					return user;
				}
			}

			return null;
		}

		#region Private Methods
		private (string Salt, string Hash) CreateHash(string password)
		{
			using (var rng = new RNGCryptoServiceProvider())
			{
				var saltBytes = new byte[SaltSize];
				rng.GetBytes(saltBytes);
				var salt = Convert.ToBase64String(saltBytes);

				var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations);
				var hashBytes = pbkdf2.GetBytes(HashSize);
				var hash = Convert.ToBase64String(hashBytes);

				return (salt, hash);
			}
		}

		private bool VerifyPassword(string password, string salt, string hash)
		{
			var saltBytes = Convert.FromBase64String(salt);
			var hashBytes = Convert.FromBase64String(hash);

			var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations);
			var testHashBytes = pbkdf2.GetBytes(HashSize);

			return SlowEquals(hashBytes, testHashBytes);
		}

		// Constant-time comparison to prevent timing attacks
		private bool SlowEquals(byte[] a, byte[] b)
		{
			if (a.Length != b.Length)
				return false;

			var diff = a.Length ^ b.Length;
			for (int i = 0; i < a.Length; i++)
			{
				diff |= a[i] ^ b[i];
			}
			return diff == 0;
		}

		#endregion
	}
}
