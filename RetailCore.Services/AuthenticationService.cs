using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IUserService _userService;
		private readonly ICryptographyService _cryptographyService;

		public AuthenticationService(IUserService userService, ICryptographyService cryptographyService)
		{
			_userService = userService;
			_cryptographyService = cryptographyService;
		}

		/// <summary>
		/// This method is used to authenticate the user with it's username and password
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public User AuthenticateUser(string userName, string password)
		{
			User exisitingUser = null;
			return _userService.VerifyUser(userName, password);
		}

	}
}
