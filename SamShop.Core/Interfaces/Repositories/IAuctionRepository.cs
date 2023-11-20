using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionRepository
    {
        IEnumerable<AuctionDtOs> GetAllAuction();
        Task<AuctionDtOs?> GetAuctionById(int id , CancellationToken cancellation);
        Task<int> AddAuction(AuctionDtOs Auction , CancellationToken cancellation);
        Task UpdateAuction(AuctionDtOs Auction , CancellationToken cancellation);
        Task DeleteAuction(int id, CancellationToken cancellation);
        
    }
}
