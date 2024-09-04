using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject = RetailCore.BusinessObjects.BusinessObjects;


namespace RetailCore.ServiceContracts
{
	public interface IRoleLevelService
	{
		IEnumerable<BusinessObject.RoleLevel> GetRoleLevels();
		BusinessObject.RoleLevel AddRoleLevel(BusinessObject.RoleLevel roleLevel);
		int GetRoleLevelCount();
	}
}
