using RetailCore.BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
	public interface IAuthenticationService
	{
		User AuthenticateUser(string userName, string password);
	}
}
