using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{

    public class RoleLevelPermissionTypeMappingRepository : Repository<RetailCore.Entities.EntityModels.RoleLevelPermissionTypeMapping>, RetailCore.Interfaces.Repository.IRoleLevelPermissionTypeMappingRepository
    {
        public RoleLevelPermissionTypeMappingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
