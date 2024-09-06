using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class OrderRepository : Repository<RetailCore.Entities.EntityModels.Order>, RetailCore.Interfaces.Repository.IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
