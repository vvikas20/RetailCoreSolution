using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductCategoryRepository : Repository<RetailCore.Entities.EntityModels.ProductCategory>, RetailCore.Interfaces.Repository.IProductCategoryRepository
    {
        public ProductCategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
