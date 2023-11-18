using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsByIsAccepted()
        {
            var Products = _productRepository.GetAllProduct();

            return Products.Where(c => c is { IsAccepted: false, IsDeleted: false });
        }

        public IEnumerable<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task AddProduct(Product Product, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product Product, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task ConfirmProduct(int productId, CancellationToken cancellation)
        {
            var result = await _productRepository.GetProductById(productId, cancellation);
            result.IsAccepted = true;

            await _productRepository.UpdateProduct(result, cancellation);

        }

        public async Task DeleteProduct(int productId, CancellationToken cancellation)
        {
            await _productRepository.DeleteProduct(productId, cancellation);

        }
    }
}
