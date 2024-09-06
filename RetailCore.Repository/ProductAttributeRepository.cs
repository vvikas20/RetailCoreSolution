using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductAttributeRepository : Repository<RetailCore.Entities.EntityModels.ProductAttribute>, RetailCore.Interfaces.Repository.IProductAttributeRepository
    {
        public ProductAttributeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}

