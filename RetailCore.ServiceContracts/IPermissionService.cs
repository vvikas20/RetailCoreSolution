using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject = RetailCore.BusinessObjects.BusinessObjects;

namespace RetailCore.ServiceContracts
{
    public interface IPermissionService
    {
        IEnumerable<BusinessObject.Permission> GetPermissions();
        IEnumerable<BusinessObject.Permission> GetUserPermissions(Guid userId);
        BusinessObject.Permission GetPermissionById(Guid permissionId);
        BusinessObject.Permission AddPermission(BusinessObject.Permission permission);
        BusinessObject.Permission UpdatePermission(BusinessObject.Permission permission);
        bool DeletePermission(Guid permissionId);
        int GetPermissionCount();

    }
}
