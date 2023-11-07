using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Task<Product?> GetProductById(int id , CancellationToken cancellation);
        Task AddProduct(Product Product, CancellationToken cancellation);
        Task UpdateProduct(Product Product , CancellationToken cancellation);
        Task DeleteProduct(int id , CancellationToken cancellation);
        IEnumerable<Product> GetProductByAccepted();
    }
}
