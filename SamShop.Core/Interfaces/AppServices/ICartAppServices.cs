using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface ICartAppServices
    {
        IEnumerable<CartDtOs> GetAllCart();
        Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation);
        Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation);
        Task UpdateCart(CartDtOs Cart, CancellationToken cancellation);
        Task DeleteCart(int id, CancellationToken cancellation);
    }
}
