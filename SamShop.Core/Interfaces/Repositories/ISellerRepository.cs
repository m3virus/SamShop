using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetAllSeller();
        Task<Seller?> GetSellerById(int id , CancellationToken cancellation);
        Task<int> AddSeller(Seller Seller , CancellationToken cancellation);
        Task UpdateSeller(Seller Seller , CancellationToken cancellation);
        Task DeleteSeller(int id, CancellationToken cancellation);
    }
}
