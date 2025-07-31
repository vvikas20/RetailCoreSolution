using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
    public interface IRoleRepository : IRepository<RetailCore.Entities.EntityModels.Role>
    {
        IEnumerable<RetailCore.Entities.EntityModels.Permission> GetPermissionByRoleId(Guid roleId);
        bool RoleCoscadeDelete(Guid roleId);
    }
}
