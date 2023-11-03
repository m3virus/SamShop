using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetAllSeller(CancellationToken cancellation);
        Task<Seller?> GetSellerById(int id , CancellationToken cancellation);
        Task AddSeller(Seller Seller , CancellationToken cancellation);
        Task UpdateSeller(Seller Seller , CancellationToken cancellation);
        Task DeleteSeller(int id, CancellationToken cancellation);
    }
}
