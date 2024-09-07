using RetailCore.BusinessObjects.BusinessObjects;
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
        BusinessObject.RoleLevel GetRoleLevelById(Guid roleLevelId);
        BusinessObject.RoleLevel AddRoleLevel(BusinessObject.RoleLevel roleLevel);
        BusinessObject.RoleLevel UpdateRoleLevel(BusinessObject.RoleLevel roleLevel);	
        bool DeleteRoleLevel(Guid roleLevelId);
        int GetRoleLevelCount();
        bool AddRoleLevelPermissionTypes(Guid roleLevelId, List<PermissionType> permissionTypes);
        bool UpdateRoleLevelPermissionTypes(Guid roleLevelId, List<PermissionType> permissionTypes);
        IEnumerable<Permission> GetRoleLevelPermissions(Guid roleLevelId);
    }
}
