using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository:IProductRepository
    {
        protected readonly SamShopDbContext _context;

        public ProductRepository(SamShopDbContext context )
        {
            _context = context;
        }

        public async Task AddProduct(Product Product, CancellationToken cancellation)

        {
            Product ProductAdding = new Product()
            {
                ProductName = Product.ProductName,
                Price = Product.Price,
                Amount = Product.Amount,
                IsDeleted = false,
                IsAvailable = true

            };
            await _context.Products.AddAsync(ProductAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Products;
        }



        public async Task<Product?> GetProductById(int id, CancellationToken cancellation)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id , cancellation);

        }

        public async Task UpdateProduct(Product Product, CancellationToken cancellation)
        {
            Product? changeProduct =
                await _context.Products.FirstOrDefaultAsync(p => p.ProductId == Product.ProductId , cancellation);
            if (changeProduct != null)
            {
                changeProduct.ProductName = Product.ProductName;
                changeProduct.CategoryId = Product.CategoryId;
                changeProduct.BoothId = Product.BoothId;
                changeProduct.Price = Product.Price;
                changeProduct.IsAvailable = true;
                changeProduct.IsAccepted = false;
                changeProduct.IsAccepted = false;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteProduct(int id, CancellationToken cancellation)
        {
            Product? removingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id , cancellation);
            if (removingProduct != null)
            {
                removingProduct.IsDeleted = true;
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
