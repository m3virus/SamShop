using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Task<Product?> GetProductById(int id);
        Task AddProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(int id);
    }
}
