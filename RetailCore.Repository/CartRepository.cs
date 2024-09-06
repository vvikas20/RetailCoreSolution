using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class CartRepository : Repository<RetailCore.Entities.EntityModels.Cart>, RetailCore.Interfaces.Repository.ICartRepository
    {
        public CartRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
