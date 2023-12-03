using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository:IProductRepository
    {
        protected readonly SamShopDbContext _context;

        public ProductRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            Product ProductAdding = new Product()
            {
                BoothId = Product.BoothId,
                CategoryId = Product.CategoryId,
                ProductName = Product.ProductName,
                Price = Product.Price,
                Amount = Product.Amount,
                IsDeleted = false,
                IsAvailable = true,
                AddTime = DateTime.Now,
                DeleteTime = null,
                IsAccepted = false,
                Pictures = Product.Pictures.Select(pictures => new Picture
                {
                    Url = pictures.Url
                }).ToList(),

            };
            await _context.Products.AddAsync(ProductAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return ProductAdding.ProductId;
        }

        public IEnumerable<ProductDtOs> GetAllProduct()
        {
            var Products = _context.Products.AsNoTracking();
            var ProductDtOs = new List<ProductDtOs>();

            foreach (var a in Products)
            {
                var Product = new ProductDtOs()
                {
                    ProductId = a.ProductId,
                    IsDeleted = a.IsDeleted,
                    DeleteTime = a.DeleteTime,
                    CategoryId = a.CategoryId,
                    ProductName = a.ProductName,
                    Price = a.Price,
                    Amount = a.Amount,
                    IsAvailable = a.IsAvailable,
                    IsAccepted = a.IsAccepted,
                    AddTime = a.AddTime,

                };
                ProductDtOs.Add(Product);
            }

            return ProductDtOs;
        }



        public async Task<ProductDtOs?> GetProductById(int id, CancellationToken cancellation)
        {
            var Product = await _context.Products
                .Include(product => product.Category)
                .Include(product => product.Pictures)
                .FirstOrDefaultAsync(a => a.ProductId == id, cancellation);

            var ProductById = new ProductDtOs()
            {
                ProductId = Product.ProductId,
                IsDeleted = Product.IsDeleted,
                Price = Product.Price,
                DeleteTime = Product.DeleteTime,
                CategoryId = Product.CategoryId,
                Amount = Product.Amount,
                IsAvailable = Product.IsAvailable,
                IsAccepted = Product.IsAccepted,
                ProductName = Product.ProductName,
                AddTime = Product.AddTime,
                Category = new Category
                {
                    CategoryName = Product.Category.CategoryName
                },
                Pictures = Product.Pictures.Where(picture => picture.IsDeleted == false).Select(p => new Picture
                {
                    PictureId = p.PictureId,
                    Url = p.Url,
                }).ToList(),
            };
            return ProductById;
        }

        public async Task UpdateProduct(ProductDtOs Product, CancellationToken cancellation)
        {
            Product? changeProduct =
                await _context.Products
                    .Include(product => product.Category)
                    .Include(product => product.Pictures)
                    .FirstOrDefaultAsync(p => p.ProductId == Product.ProductId, cancellation);
            if (changeProduct != null)
            {
                changeProduct.ProductName = Product.ProductName;
                changeProduct.CategoryId = Product.Category.CategoryId;
                //changeProduct.BoothId = Product.BoothId;
                changeProduct.Price = Product.Price;
                changeProduct.IsAvailable = Product.IsAvailable;
                changeProduct.IsAccepted = Product.IsAccepted;
                changeProduct.Amount = Product.Amount;
                changeProduct.Pictures = Product.Pictures.Select(picture => new Picture
                {
                    PictureId = picture.PictureId,
                    Url = picture.Url
                }).ToList();

            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteProduct(int id, CancellationToken cancellation)
        {
            Product? removingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id, cancellation);
            if (removingProduct != null)
            {
                removingProduct.IsDeleted = true;
                removingProduct.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }

        public async Task ConfirmProduct(int productId, CancellationToken cancellation)
        {
            Product? confirmingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId, cancellation);
            if (confirmingProduct != null)
            {
                confirmingProduct.IsAccepted = true;
            }

            await _context.SaveChangesAsync(cancellation);

        }

    }
}
