using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class WishlistProductRepository : Repository<RetailCore.Entities.EntityModels.WishlistProduct>, RetailCore.Interfaces.Repository.IWishlistProductRepository
    {
        public WishlistProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
