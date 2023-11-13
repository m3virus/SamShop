using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAllAuction();
        Task<Auction?> GetAuctionById(int id , CancellationToken cancellation);
        Task AddAuction(Auction Auction , CancellationToken cancellation);
        Task UpdateAuction(Auction Auction , CancellationToken cancellation);
        Task DeleteAuction(int id, CancellationToken cancellation);
        
    }
}
