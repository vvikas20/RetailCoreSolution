using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
    public interface IRoleLevelPermissionTypeMappingRepository : IRepository<RetailCore.Entities.EntityModels.RoleLevelPermissionTypeMapping>
    {
        IEnumerable<PermissionType> GetRoleLevelPermissionTypes(Guid roleLevelId);
    }
}
