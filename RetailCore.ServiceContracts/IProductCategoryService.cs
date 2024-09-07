using RetailCore.BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
    public interface IProductCategoryService
    {
        int GetProductCategoryCount();
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryById(Guid productCategoryId);
        Guid AddProductCategory(ProductCategory productCategory);
    }
}
