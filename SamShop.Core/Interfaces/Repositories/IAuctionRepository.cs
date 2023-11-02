using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAllAuction();
        Task<Auction?> GetAuctionById(int id);
        Task AddAuction(Auction Auction);
        Task UpdateAuction(Auction Auction);
        Task DeleteAuction(int id);
    }
}
