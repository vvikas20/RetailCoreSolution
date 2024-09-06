using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class PermissionRepository : Repository<RetailCore.Entities.EntityModels.Permission>, RetailCore.Interfaces.Repository.IPermissionRepository
    {
        public PermissionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
