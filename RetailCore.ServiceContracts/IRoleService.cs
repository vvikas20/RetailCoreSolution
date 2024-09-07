using RetailCore.BusinessObjects.BusinessObjects;
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
        BusinessObject.Role GetRoleById(Guid roleId);
        BusinessObject.Role AddRole(BusinessObject.Role role);
        BusinessObject.Role UpdateRole(BusinessObject.Role role);
        bool DeleteRole(Guid roleId);
        int GetRoleCount();
        bool AssignDefaultPermissionOnRole(Guid roleId);
        bool AssignPermissionsToRole(Guid roleId, List<Permission> permissions);
        IEnumerable<BusinessObject.Permission> GetPermissionByRoleId(Guid roleId);
    }
}
