using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionOfferRepository
    {
        IEnumerable<AuctionOffer> GetAllAuctionOffer(CancellationToken cancellation);
        Task<AuctionOffer?> GetAuctionOfferById(int id , CancellationToken cancellation);
        Task AddAuctionOffer(AuctionOffer AuctionOffer , CancellationToken cancellation);
        Task UpdateAuctionOffer(AuctionOffer AuctionOffer , CancellationToken cancellation);
        Task DeleteAuctionOffer(int id , CancellationToken cancellation);
    }
}
