using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategory();
        Task<Category?> GetCategoryById(int id , CancellationToken cancellation);
        Task AddCategory(Category Category, CancellationToken cancellation);
        Task UpdateCategory(Category Category, CancellationToken cancellation);
        Task DeleteCategory(int id , CancellationToken cancellation);
    }
}
