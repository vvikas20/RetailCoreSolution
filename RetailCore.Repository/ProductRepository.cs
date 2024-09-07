using Microsoft.EntityFrameworkCore;
using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class ProductRepository : Repository<RetailCore.Entities.EntityModels.Product>, RetailCore.Interfaces.Repository.IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public IEnumerable<Entities.EntityModels.Product> GetAllProductFull()
        {
            return base.dbset.Include(x => x.Category).ToList();
        }
    }
}
