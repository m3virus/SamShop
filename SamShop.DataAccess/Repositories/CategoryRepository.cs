using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.CategoryDtOs;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        protected readonly SamShopDbContext _context;

        public CategoryRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCategory(CategoryDtOs Category, CancellationToken cancellation)

        {
            Category CategoryAdding = new Category()
            {
                CategoryName = Category.CategoryName,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                DeleteTime = null
                

            };
            await _context.Categories.AddAsync(CategoryAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CategoryAdding.CategoryId;
        }

        public async Task UpdateCategory(CategoryDtOs Category, CancellationToken cancellation)
        {
            Category? changeCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == Category.CategoryId, cancellation);
            if (changeCategory != null)
            {
                changeCategory.CategoryName = Category.CategoryName;
                changeCategory.IsAccepted = changeCategory.IsAccepted;


            }

            await _context.SaveChangesAsync(cancellation);
        }

        public async Task DeleteCategory(int id, CancellationToken cancellation)
        {
            Category? removingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id, cancellation);
            if (removingCategory != null)
            {
                removingCategory.IsDeleted = true;
                removingCategory.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<CategoryDtOs> GetAllCategory()
        {
            var Categories = _context.Categories
                .Include(c => c.Products)
                .ThenInclude(p => p.Pictures)
                .Include(c => c.Products)
                .ThenInclude(c => c.Booth);
            var CategoryDtOs = new List<CategoryDtOs>();

            foreach (var Category in Categories)
            {
                var a = new CategoryDtOs()
                {
                    CategoryId = Category.CategoryId,
                    CategoryName = Category.CategoryName,
                    IsDeleted = Category.IsDeleted,
                    CreateTime = Category.CreateTime,
                    DeleteTime = Category.DeleteTime,
                    IsAccepted = Category.IsAccepted,
                    Products = Category.Products.Select(product => new Product
                    {
                        IsAccepted = product.IsAccepted,
                        IsDeleted = product.IsDeleted,
                        IsAvailable = product.IsAvailable,
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Amount = product.Amount,
                        Price = product.Price,
                        Pictures = product.Pictures.Select(picture => new Picture
                        {
                            Url = picture.Url
                        }).ToList(),
                        Booth = new Booth
                        {
                            BoothId = product.BoothId,
                            BoothName = product.Booth.BoothName
                        }
                    }).ToList(),

                };
                CategoryDtOs.Add(a);
            }

            return CategoryDtOs;
        }
    }
}
