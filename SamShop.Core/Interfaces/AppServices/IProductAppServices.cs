using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IProductAppServices
    {
        Task ConfirmProduct(int ProductId, CancellationToken cancellation);
        IEnumerable<ProductDtOs> GetProductsByIsAccepted();
        IEnumerable<ProductDtOs> GetAllProduct();
        Task<ProductDtOs?> GetProductById(int id, CancellationToken cancellation);
        Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation);
        Task UpdateProduct(ProductDtOs Product, CancellationToken cancellation);
        Task DeleteProduct(int id, CancellationToken cancellation);
    }
}
