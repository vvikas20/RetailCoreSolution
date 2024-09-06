using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class RolePermissionRepository : Repository<RetailCore.Entities.EntityModels.RolePermission>, RetailCore.Interfaces.Repository.IRolePermissionRepository
    {
        public RolePermissionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
