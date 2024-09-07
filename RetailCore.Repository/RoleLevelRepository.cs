using Microsoft.EntityFrameworkCore;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{

    public class RoleLevelRepository : Repository<RetailCore.Entities.EntityModels.RoleLevel>, RetailCore.Interfaces.Repository.IRoleLevelRepository
    {
        public RoleLevelRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public IEnumerable<RetailCore.Entities.EntityModels.Permission> GetRoleLevelDefaultPermissions(Guid roleLevelId)
        {
            var roleLevels = base.dbset.Include(rl => rl.RoleLevelPermissionTypeMappings).ThenInclude(rlptm => rlptm.PermissionType).ThenInclude(pt => pt.Permissions).Where(rl => rl.RoleLevelId == roleLevelId).ToList();
            if (roleLevels.Count > 0)
            {
                return roleLevels[0].RoleLevelPermissionTypeMappings.SelectMany(rlptm => rlptm.PermissionType.Permissions).ToList();
            }

            return new List<RetailCore.Entities.EntityModels.Permission>();
        }

        public IEnumerable<RetailCore.Entities.EntityModels.PermissionType> GetRoleLevelDefaultPermissionTypes(Guid roleLevelId)
        {
            var roleLevels = base.dbset.Include(rl => rl.RoleLevelPermissionTypeMappings).ThenInclude(rlptm => rlptm.PermissionType).Where(rl => rl.RoleLevelId == roleLevelId).ToList();
            if (roleLevels.Count > 0)
            {
                return roleLevels[0].RoleLevelPermissionTypeMappings.Select(rlptm => rlptm.PermissionType).ToList();
            }

            return new List<RetailCore.Entities.EntityModels.PermissionType>();
        }

    }
}
