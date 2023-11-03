using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class CategoryRepository:ICategoryRepository
    {
        protected readonly SamShopDbContext _context;

        public CategoryRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category Category , CancellationToken cancellation)

        {
            Category CategoryAdding = new Category()
            {
                CategoryName = Category.CategoryName,
                IsDeleted = false,

            };
            await _context.Categories.AddAsync(CategoryAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories;
        }



        public async Task<Category?> GetCategoryById(int id , CancellationToken cancellation)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id, cancellation);

        }
        public async Task UpdateCategory(Category Category, CancellationToken cancellation)
        {
            Category? changeCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == Category.CategoryId, cancellation);
            if (changeCategory != null)
            {
                changeCategory.CategoryName = Category.CategoryName;
                changeCategory.IsAccepted = changeCategory.IsAccepted;


            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCategory(int id , CancellationToken cancellation)
        {
            Category? removingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id, cancellation);
            if (removingCategory != null)
            {
                removingCategory.IsDeleted = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
