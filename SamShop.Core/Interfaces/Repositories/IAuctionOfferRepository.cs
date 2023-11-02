using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionOfferRepository
    {
        IEnumerable<AuctionOffer> GetAllAuctionOffer();
        Task<AuctionOffer?> GetAuctionOfferById(int id);
        Task AddAuctionOffer(AuctionOffer AuctionOffer);
        Task UpdateAuctionOffer(AuctionOffer AuctionOffer);
        Task DeleteAuctionOffer(int id);
    }
}
