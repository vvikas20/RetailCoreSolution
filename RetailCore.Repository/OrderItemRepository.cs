using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class OrderItemRepository : Repository<RetailCore.Entities.EntityModels.OrderItem>, RetailCore.Interfaces.Repository.IOrderItemRepository
    {
        public OrderItemRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
