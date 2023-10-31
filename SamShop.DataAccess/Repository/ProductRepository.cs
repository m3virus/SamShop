using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Application.EntityFramework.DBContext;
using SamShop.Domain.Core.Interfaces.IRepository;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Application.DataAccess.Repository
{
    internal class ProductRepository:IProductRepository
    {
        protected readonly SamShopDbContext _context;

        public ProductRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product Product)

        {
            Product ProductAdding = new Product()
            {
                ProductName = Product.ProductName,
                Price = Product.Price,
                IsDeleted = false,
                IsAvailable = true

            };
            await _context.Products.AddAsync(ProductAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Products;
        }



        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

        }

        public async Task UpdateProduct(Product Product)
        {
            Product? changeProduct =
                await _context.Products.FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);
            if (changeProduct != null)
            {
                changeProduct.ProductName = Product.ProductName;
                changeProduct.Price = Product.Price;
                changeProduct.IsAvailable = true;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteProduct(int id)
        {
            Product? removingaProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (removingaProduct != null)
            {
                _context.Remove(removingaProduct);
            }

            await _context.SaveChangesAsync();
        }
    }
}
