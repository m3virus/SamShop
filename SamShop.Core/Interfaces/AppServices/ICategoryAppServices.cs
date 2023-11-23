using SamShop.Domain.Core.Models.DtOs.CategoryDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface ICategoryAppServices
    {
        IEnumerable<CategoryDtOs> GetAllCategory();
        Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation);
        Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation);
        Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation);
        Task DeleteCategory(int id, CancellationToken cancellation);
    }
}
