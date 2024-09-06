using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class CartItemRepository : Repository<RetailCore.Entities.EntityModels.CartItem>, RetailCore.Interfaces.Repository.ICartItemRepository
    {
        public CartItemRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
