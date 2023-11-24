using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;

namespace SamShop.Domain.Appservices
{
    public class ProductAppServices :IProductAppServices
    {
        protected readonly IProductServices _productServices;

        public ProductAppServices(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task ConfirmProduct(int ProductId, CancellationToken cancellation)
        {
            await _productServices.ConfirmProduct(ProductId, cancellation);
        }

        public IEnumerable<ProductDtOs> GetProductsByIsAccepted()
        {
            return _productServices.GetProductsByIsAccepted();
        }

        public IEnumerable<ProductDtOs> GetAllProduct()
        {
            return _productServices.GetAllProduct().Where(x => x.IsDeleted != true);
        }

        public async Task<ProductDtOs?> GetProductById(int id, CancellationToken cancellation)
        {
            return await _productServices.GetProductById(id , cancellation);
        }

        public async Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            return await _productServices.AddProduct(Product ,cancellation);
        }

        public async Task UpdateProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            await _productServices.UpdateProduct(Product ,cancellation);
        }

        public async Task DeleteProduct(int id, CancellationToken cancellation)
        {
            await _productServices.DeleteProduct(id, cancellation);
        }
    }
}
