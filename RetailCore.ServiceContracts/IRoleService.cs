using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject = RetailCore.BusinessObjects.BusinessObjects;


namespace RetailCore.ServiceContracts
{
	public interface IRoleService
	{
		IEnumerable<BusinessObject.Role> GetRoles();
		BusinessObject.Role AddRole(BusinessObject.Role role);
		int GetRoleCount();
	}
}
