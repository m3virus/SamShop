using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategory();
        Task<Category?> GetCategoryById(int id);
        Task AddCategory(Category Category);
        Task UpdateCategory(Category Category);
        Task DeleteCategory(int id);
    }
}
