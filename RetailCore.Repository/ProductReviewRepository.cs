using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductReviewRepository : Repository<RetailCore.Entities.EntityModels.ProductReview>, RetailCore.Interfaces.Repository.IProductReviewRepository
    {
        public ProductReviewRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
