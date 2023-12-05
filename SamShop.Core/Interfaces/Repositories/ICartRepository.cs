using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<CartDtOs> GetAllCart();
        Task<CartDtOs?> GetCartById(int id , CancellationToken cancellation);
        Task<int> AddCart(CartDtOs Cart , CancellationToken cancellation);
        Task UpdateCart(CartDtOs Cart , CancellationToken cancellation);
        Task DeleteCart(int id , CancellationToken cancellation);
        Task AddCartForAuction(CartDtOs Cart, CancellationToken cancellation);
    }
}
