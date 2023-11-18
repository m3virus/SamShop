using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICartServices
    {
        IEnumerable<Cart> GetAllCart();
        Task<Cart?> GetCartById(int id, CancellationToken cancellation);
        Task AddCart(Cart Cart, CancellationToken cancellation);
        Task UpdateCart(Cart Cart, CancellationToken cancellation);
        Task DeleteCart(int id, CancellationToken cancellation);
    }
}
