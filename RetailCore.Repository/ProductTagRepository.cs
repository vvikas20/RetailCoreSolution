using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductTagRepository : Repository<RetailCore.Entities.EntityModels.ProductTag>, RetailCore.Interfaces.Repository.IProductTagRepository
    {
        public ProductTagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
