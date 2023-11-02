using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Task<Product?> GetProductById(int id);
        Task AddProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(int id);
    }
}
