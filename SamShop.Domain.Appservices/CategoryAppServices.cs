using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CategoryDtOs;

namespace SamShop.Domain.Appservices
{
    public class CategoryAppServices : ICategoryAppServices
    {
        protected readonly ICategoryServices _categoryServices;

        public CategoryAppServices(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IEnumerable<CategoryDtOs> GetAllCategory()
        {
            return _categoryServices.GetAllCategory();
        }

        public async Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation)
        {
            return await _categoryServices.GetCategoryById(id, cancellation);
        }

        public async Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            return await _categoryServices.AddCategory(Category, cancellation);
        }

        public async Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            await _categoryServices.UpdateCategory(Category, cancellation);
        }

        public async Task DeleteCategory(int id, CancellationToken cancellation)
        {
            await _categoryServices.DeleteCategory(id, cancellation);
        }
    }
}
