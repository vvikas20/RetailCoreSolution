using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
    public interface IProductService
    {
        BusinessObjects.BusinessObjects.Product AddProduct(BusinessObjects.BusinessObjects.Product product);
        BusinessObjects.BusinessObjects.Product UpdateProduct(BusinessObjects.BusinessObjects.Product product);
        BusinessObjects.BusinessObjects.Product GetProduct(Guid productId);
        IEnumerable<BusinessObjects.BusinessObjects.Product> GetProducts();
        void DeleteProduct(Guid productId);
    }
}
