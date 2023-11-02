using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
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
