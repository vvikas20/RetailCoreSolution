using Microsoft.EntityFrameworkCore;
using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance;
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

        public bool RoleCoscadeDelete(Guid roleId)
        {
            var entityToDelete = base.dbset.Include(x => x.Users)
                                           .Include(x => x.RolePermissions)
                                           .FirstOrDefault(x => x.RoleId == roleId);
            if (entityToDelete != null)
            {
                //Delete the RoleLevel associated with the Role
                if (entityToDelete.RoleLevel != null)
                {
                    base.dataContext.Entry(entityToDelete.RoleLevel).State = EntityState.Deleted;
                }

                //Detach the CreatedBy and ModifiedBy User objects to prevent their deletion
                if (entityToDelete.CreatedByNavigation != null)
                {
                    base.dataContext.Entry(entityToDelete.CreatedByNavigation).State = EntityState.Detached;
                }
                if (entityToDelete.ModifiedByNavigation != null)
                {
                    base.dataContext.Entry(entityToDelete.ModifiedByNavigation).State = EntityState.Detached;
                }

                // Detach the Permission objects from RolePermissions to prevent their deletion
                foreach (var rolePermission in entityToDelete.RolePermissions)
                {
                    base.dataContext.Entry(rolePermission.Permission).State = EntityState.Detached;
                }

                EntityFrameworkRecursiveDeleter.DeleteEntityWithDependencies(base.dataContext, entityToDelete);
            }

            return true;
        }
    }
}
