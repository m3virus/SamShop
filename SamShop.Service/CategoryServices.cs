using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CategoryDtOs;

namespace SamShop.Domain.Service
{
    public class CategoryServices : ICategoryServices
    {
        protected readonly ICategoryRepository _CategoryRepository;

        public CategoryServices(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public IEnumerable<CategoryDtOs> GetAllCategory()
        {
            return _CategoryRepository.GetAllCategory();
        }

        public async Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation)
        {
            return await _CategoryRepository.GetCategoryById(id, cancellation);
        }

        public async Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            return await _CategoryRepository.AddCategory(Category, cancellation);
        }

        public async Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            await _CategoryRepository.UpdateCategory(Category, cancellation);
        }

        public async Task DeleteCategory(int id, CancellationToken cancellation)
        {
            await _CategoryRepository.DeleteCategory(id, cancellation);
        }
    }
}
