using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductTagMappingRepository : Repository<RetailCore.Entities.EntityModels.ProductTagMapping>, RetailCore.Interfaces.Repository.IProductTagMappingRepository
    {
        public ProductTagMappingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
