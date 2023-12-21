using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
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

        public async Task<CategoryDtOs?> GetCategoryById(int id, CancellationToken cancellation)
        {
            var category = await _context.Categories.AsNoTracking()
                .Include(booth => booth.Products)
                .ThenInclude(product => product.Booth)
                .Include(booth => booth.Products)
                .ThenInclude(product => product.Pictures).Include(category => category.Products)
                .ThenInclude(product => product.Comments).ThenInclude(comment => comment.Customer)
                .ThenInclude(customer => customer.AppUser)
                .FirstOrDefaultAsync(a => a.CategoryId == id, cancellation);

            var categoryById = new CategoryDtOs()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                
                IsDeleted = category.IsDeleted,
                CreateTime = category.CreateTime,
                DeleteTime = category.DeleteTime,

                Products = category.Products.Where(product => product.IsDeleted !=true).Select(categoryProduct => new Product
                {
                    ProductId = categoryProduct.ProductId,
                    ProductName = categoryProduct.ProductName,
                    Price = categoryProduct.Price,
                    Amount = categoryProduct.Amount,
                    IsAccepted = categoryProduct.IsAccepted,
                    IsDeleted = categoryProduct.IsDeleted,
                    IsAvailable = categoryProduct.IsAvailable,
                    Comments = categoryProduct.Comments.Select(comment => new Comment
                    {
                        CommentId = comment.CommentId,
                        CommentDate = comment.CommentDate,
                        Message = comment.Message,
                        IsAccepted = comment.IsAccepted,
                        IsDeleted = comment.IsDeleted,
                        Customer = new Customer
                        {
                            CustomerId = comment.Customer.CustomerId,
                            AppUser = new AppUser
                            {
                                UserName = comment.Customer.AppUser.UserName
                            }
                        }
                    }).ToList(),
                    Pictures = categoryProduct.Pictures.Where(picture => picture.IsDeleted == false).Select(productPictures => new Picture
                    {
                        Url = productPictures.Url,
                    }).ToList(),
                    Booth = new Booth
                    {
                        BoothId = categoryProduct.Booth.BoothId,
                        BoothName = categoryProduct.Booth.BoothName,
                    }
                }).ToList(),

            };
            return categoryById;
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
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.Customer)
                .ThenInclude(c => c.AppUser)
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
