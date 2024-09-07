using RetailCore.BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
    public interface IPermissionTypeService
    {
        int GetPermissionTypeCount();
        List<PermissionType> GetPermissionTypes();
        PermissionType GetPermissionTypeById(Guid permissionTypeId);
        Guid AddPermissionType(PermissionType permissionType);
        List<Guid> AddPermissionTypes(List<PermissionType> permissionTypes);
    }
}
