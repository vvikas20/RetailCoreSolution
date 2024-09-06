using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ShippingRepository : Repository<RetailCore.Entities.EntityModels.Shipping>, RetailCore.Interfaces.Repository.IShippingRepository
    {
        public ShippingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
