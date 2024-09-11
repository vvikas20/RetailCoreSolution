using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
	public interface IJwtService
	{
		string GenerateToken(string userID, bool isRememberMe);
		ClaimsPrincipal GetPrincipalFromToken(string token);
	}
}
