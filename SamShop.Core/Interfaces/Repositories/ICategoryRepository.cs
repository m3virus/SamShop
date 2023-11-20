using SamShop.Domain.Core.Models.DtOs.CategoryDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDtOs> GetAllCategory();
        Task<CategoryDtOs?> GetCategoryById(int id , CancellationToken cancellation);
        Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation);
        Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation);
        Task DeleteCategory(int id , CancellationToken cancellation);
    }
}
