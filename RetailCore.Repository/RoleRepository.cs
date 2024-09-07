using Microsoft.EntityFrameworkCore;
using RetailCore.Entities.EntityModels;
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

    public class RoleRepository : Repository<RetailCore.Entities.EntityModels.Role>, RetailCore.Interfaces.Repository.IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public IEnumerable<Permission> GetPermissionByRoleId(Guid roleId)
        {
            var existingRole = base.dbset.Include(x => x.RolePermissions).ThenInclude(x => x.Permission.PermissionType).Where(x => x.RoleId == roleId).FirstOrDefault();
            if (existingRole != null)
            {
                return existingRole.RolePermissions.Select(x => x.Permission).ToList();
            }

            return new List<Permission>();
        }
    }
}
