using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Mapper;
using RetailCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Services
{
    public class ProductService : IProductService
    {


        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }



        public Product AddProduct(Product product)
        {
            _productRepository.Add(product.ToEntityModel());
            _unitOfWork.Commit();
            return product;
        }

        public void DeleteProduct(Guid productId)
        {
            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct != null)
            {
                _productRepository.Delete(existingProduct);
                _unitOfWork.Commit();
            }
        }

        public Product GetProduct(Guid productId)
        {
            return _productRepository.GetById(productId).ToBusinessObject();
        }

        public IEnumerable<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();
            foreach (var product in _productRepository.GetAllProductFull())
            {
                var productObj = product.ToBusinessObject();
                productObj.Category = product.Category?.ToBusinessObject();
                products.Add(productObj);
            }
            return products;
        }

        public Product UpdateProduct(Product product)
        {
            var existingProduct = _productRepository.GetById(product.ProductId);
            if (existingProduct != null)
            {
                _productRepository.Update(product.ToEntityModel(existingProduct));
                _unitOfWork.Commit();
            }

            return product;
        }
    }
}
