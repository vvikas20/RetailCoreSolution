using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductAttributeMappingRepository : Repository<RetailCore.Entities.EntityModels.ProductAttributeMapping>, RetailCore.Interfaces.Repository.IProductAttributeMappingRepository
    {
        public ProductAttributeMappingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
