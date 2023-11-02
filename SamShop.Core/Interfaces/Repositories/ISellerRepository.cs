using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetAllSeller();
        Task<Seller?> GetSellerById(int id);
        Task AddSeller(Seller Seller);
        Task UpdateSeller(Seller Seller);
        Task DeleteSeller(int id);
    }
}
