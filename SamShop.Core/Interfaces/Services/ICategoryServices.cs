using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAllCategory();
        Task<Category?> GetCategoryById(int id, CancellationToken cancellation);
        Task AddCategory(Category Category, CancellationToken cancellation);
        Task UpdateCategory(Category Category, CancellationToken cancellation);
        Task DeleteCategory(int id, CancellationToken cancellation);
    }
}
