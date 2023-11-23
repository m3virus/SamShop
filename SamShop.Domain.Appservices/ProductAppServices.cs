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
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDtOs> GetProductsByIsAccepted()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDtOs> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDtOs?> GetProductById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
