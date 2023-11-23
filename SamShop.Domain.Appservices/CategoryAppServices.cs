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
            throw new NotImplementedException();
        }

        public async Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategory(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
