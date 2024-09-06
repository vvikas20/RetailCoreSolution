using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class WishlistRepository : Repository<RetailCore.Entities.EntityModels.Wishlist>, RetailCore.Interfaces.Repository.IWishlistRepository
    {
        public WishlistRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
