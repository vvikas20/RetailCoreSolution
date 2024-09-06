using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{

    public class PermissionTypeRepository : Repository<RetailCore.Entities.EntityModels.PermissionType>, RetailCore.Interfaces.Repository.IPermissionTypeRepository
    {
        public PermissionTypeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
