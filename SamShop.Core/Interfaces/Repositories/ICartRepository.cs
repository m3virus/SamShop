using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCart();
        Task<Cart?> GetCartById(int id , CancellationToken cancellation);
        Task AddCart(Cart Cart , CancellationToken cancellation);
        Task UpdateCart(Cart Cart , CancellationToken cancellation);
        Task DeleteCart(int id , CancellationToken cancellation);
    }
}
