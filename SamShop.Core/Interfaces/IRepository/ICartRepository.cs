using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCart();
        Task<Cart?> GetCartById(int id);
        Task AddCart(Cart Cart);
        Task UpdateCart(Cart Cart);
        Task DeleteCart(int id);
    }
}
