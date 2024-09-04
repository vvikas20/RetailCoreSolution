using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
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
		private readonly IUserRoleRepository _userRoleRepository;

		public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
		{
			this._unitOfWork = unitOfWork;
			this._userRepository = userRepository;
			this._userRoleRepository = userRoleRepository;
		}

		public BusinessObjects.BusinessObjects.User AddUser(BusinessObjects.BusinessObjects.User user)
		{
			var saltAndHash = CreateHash(user.Password);

			this._userRepository.Add(new Entities.EntityModels.User
			{
				UserId = user.UserId,
				Username = user.Username,
				FirstName = user.FirstName,
				MiddleName = user.MiddleName,
				LastName = user.LastName,
				Email = user.Email,
				Salt = Convert.FromBase64String(saltAndHash.Salt),
				PasswordHash = Convert.FromBase64String(saltAndHash.Hash),
				IsActive = user.IsActive,
				Verified = user.Verified,
				CreatedBy = user.CreatedBy,
				CreatedOn = user.CreatedOn,
				ModifiedBy = user.ModifiedBy,
				ModifiedOn = user.ModifiedOn
			});

			this.AddUserRole(user.UserId, user.RoleId);

			this._unitOfWork.Commit();
			return user;
		}

		public bool AddUserRole(Guid userId, Guid roleId)
		{
			if (roleId == default(Guid)) return false;

			this._userRoleRepository.Add(new Entities.EntityModels.UserRole
			{
				UserRoleId = Guid.NewGuid(),
				UserId = userId,
				RoleId = roleId
			});

			this._unitOfWork.Commit();

			return true;
		}

		public BusinessObjects.BusinessObjects.User GetAdminUser()
		{
			var adminUserEntity = this._userRepository.Get(x => x.Username == "sa");
			if (adminUserEntity == null)
				return null;
			else
				return new BusinessObjects.BusinessObjects.User
				{
					UserId = adminUserEntity.UserId,
					Username = adminUserEntity.Username,
					FirstName = adminUserEntity.FirstName,
					MiddleName = adminUserEntity.MiddleName,
					LastName = adminUserEntity.LastName,
					Email = adminUserEntity.Email,
					IsActive = adminUserEntity.IsActive,
					Verified = adminUserEntity.Verified,
					CreatedBy = adminUserEntity.CreatedBy,
					CreatedOn = adminUserEntity.CreatedOn,
					ModifiedBy = adminUserEntity.ModifiedBy,
					ModifiedOn = adminUserEntity.ModifiedOn
				};
		}

		public IEnumerable<BusinessObjects.BusinessObjects.User> GetUsers()
		{
			IList<BusinessObjects.BusinessObjects.User> users = new List<BusinessObjects.BusinessObjects.User>();

			foreach (var item in this._userRepository.GetAll())
			{
				users.Add(new BusinessObjects.BusinessObjects.User
				{
					UserId = item.UserId,
					Username = item.Username,
					FirstName = item.FirstName,
					MiddleName = item.MiddleName,
					LastName = item.LastName,
					Email = item.Email,
					IsActive = item.IsActive,
					Verified = item.Verified,
					CreatedBy = item.CreatedBy,
					CreatedOn = item.CreatedOn,
					ModifiedBy = item.ModifiedBy,
					ModifiedOn = item.ModifiedOn
				});
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
			if (existingUser != null && VerifyPassword(password, Convert.ToBase64String(existingUser.Salt), Convert.ToBase64String(existingUser.PasswordHash)))
			{
				return new BusinessObjects.BusinessObjects.User
				{
					UserId = existingUser.UserId,
					Username = existingUser.Username,
					FirstName = existingUser.FirstName,
					MiddleName = existingUser.MiddleName,
					LastName = existingUser.LastName,
					Email = existingUser.Email,
					IsActive = existingUser.IsActive,
					Verified = existingUser.Verified,
					CreatedBy = existingUser.CreatedBy,
					CreatedOn = existingUser.CreatedOn,
					ModifiedBy = existingUser.ModifiedBy,
					ModifiedOn = existingUser.ModifiedOn
				};
			}

			return null;
		}

		public BusinessObjects.BusinessObjects.User GetUserById(Guid currentUser)
		{
			var userData = this._userRepository.LoadUserData(currentUser);
			if (userData != null)
			{
				return new BusinessObjects.BusinessObjects.User
				{
					UserId = userData.UserId,
					Username = userData.Username,
					FirstName = userData.FirstName,
					MiddleName = userData.MiddleName,
					LastName = userData.LastName,
					Email = userData.Email,
					IsActive = userData.IsActive,
					Verified = userData.Verified,
					CreatedBy = userData.CreatedBy,
					CreatedOn = userData.CreatedOn,
					ModifiedBy = userData.ModifiedBy,
					ModifiedOn = userData.ModifiedOn,
					UserRoles = userData.UserRoles.Select(x => new BusinessObjects.BusinessObjects.UserRole
					{
						UserRoleId = x.UserRoleId,
						UserId = x.UserId,
						RoleId = x.RoleId,
						Role = new BusinessObjects.BusinessObjects.Role { RoleDisplayName = x.Role.RoleDisplayName, RoleLevel = new BusinessObjects.BusinessObjects.RoleLevel { RoleLevelDisplayName = x.Role.RoleLevel.RoleLevelDisplayName } },
						User = new BusinessObjects.BusinessObjects.User()
					}).ToList()
				};
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
