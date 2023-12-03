using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductDtOs> GetAllProduct();
        Task<ProductDtOs?> GetProductById(int id , CancellationToken cancellation);
        Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation);
        Task UpdateProduct(ProductDtOs Product , CancellationToken cancellation);
        Task DeleteProduct(int id , CancellationToken cancellation);
        Task ConfirmProduct(int productId, CancellationToken cancellation);


    }
}
