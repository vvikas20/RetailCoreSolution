using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductImageRepository : Repository<RetailCore.Entities.EntityModels.ProductImage>, RetailCore.Interfaces.Repository.IProductImageRepository
    {
        public ProductImageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
