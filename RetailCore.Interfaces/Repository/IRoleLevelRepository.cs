using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
    public interface IRoleLevelRepository : IRepository<RetailCore.Entities.EntityModels.RoleLevel>
    {
        IEnumerable<RetailCore.Entities.EntityModels.Permission> GetRoleLevelDefaultPermissions(Guid roleLevelId);
        IEnumerable<RetailCore.Entities.EntityModels.PermissionType> GetRoleLevelDefaultPermissionTypes(Guid roleLevelId);
    }
}
