using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{

    public class CouponRepository : Repository<RetailCore.Entities.EntityModels.Coupon>, RetailCore.Interfaces.Repository.ICouponRepository
    {
        public CouponRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
