using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Mapper;
using RetailCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject = RetailCore.BusinessObjects.BusinessObjects;

namespace RetailCore.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(ICurrentUserService currentUserService, IUnitOfWork unitOfWork, IProductCategoryRepository productCategoryRepository)
        {
            this._currentUserService = currentUserService;
            this._unitOfWork = unitOfWork;
            this._productCategoryRepository = productCategoryRepository;
        }


        public Guid AddProductCategory(BusinessObject.ProductCategory productCategory)
        {
            this._productCategoryRepository.Add(productCategory.ToEntityModel());
            this._unitOfWork.Commit();
            return productCategory.ProductCategoryId;
        }

        public BusinessObject.ProductCategory GetProductCategoryById(Guid productCategoryId)
        {
           var productCategory = this._productCategoryRepository.GetById(productCategoryId);
            return productCategory.ToBusinessObject();
        }

        public List<BusinessObject.ProductCategory> GetProductCategories()
        {
            var productCategories = this._productCategoryRepository.GetAll();
            return productCategories.Select(x => x.ToBusinessObject()).ToList();
        }

        public int GetProductCategoryCount()
        {
            return this._productCategoryRepository.GetAll().Count();
        }
    }
}
