using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class AddressRepository : Repository<Entities.EntityModels.Address>, RetailCore.Interfaces.Repository.IAddressRepository
    {
        public AddressRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
