using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class ProductServices : IProductServices
    {

        protected readonly IProductRepository _ProductRepository;

        public ProductServices(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public IEnumerable<ProductDtOs> GetProductsByIsAccepted()
        {
            return _ProductRepository.GetAllProduct().Where(x => x.IsAccepted != true && x.IsDeleted != true);
        }

        public IEnumerable<ProductDtOs> GetAllProduct()
        {
            return _ProductRepository.GetAllProduct();
        }

        public async Task<ProductDtOs?> GetProductById(int id, CancellationToken cancellation)
        {
            return await _ProductRepository.GetProductById(id, cancellation);
        }

        public async Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            return await _ProductRepository.AddProduct(Product, cancellation);
        }

        public async Task UpdateProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            await _ProductRepository.UpdateProduct(Product, cancellation);
        }


        public async Task ConfirmProduct(int productId, CancellationToken cancellation)
        {
            var result = await _ProductRepository.GetProductById(productId, cancellation);
            result.IsAccepted = true;

            await _ProductRepository.UpdateProduct(result, cancellation);

        }

        public async Task DeleteProduct(int productId, CancellationToken cancellation)
        {
            await _ProductRepository.DeleteProduct(productId, cancellation);

        }
    }
}
