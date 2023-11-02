using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repository
{
    internal class CategoryRepository:ICategoryRepository
    {
        protected readonly SamShopDbContext _context;

        public CategoryRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category Category)

        {
            Category CategoryAdding = new Category()
            {
                CategoryName = Category.CategoryName,
                IsDeleted = false,

            };
            await _context.Categories.AddAsync(CategoryAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories;
        }



        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

        }
        public async Task UpdateCategory(Category Category)
        {
            Category? changeCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == Category.CategoryId);
            if (changeCategory != null)
            {
                changeCategory.CategoryName = Category.CategoryName;
                

            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteCategory(int id)
        {
            Category? removingaCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (removingaCategory != null)
            {
                _context.Remove(removingaCategory);
            }
            await _context.SaveChangesAsync();
        }
    }
}
