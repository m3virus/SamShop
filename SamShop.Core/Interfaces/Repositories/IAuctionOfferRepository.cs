using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAuctionOfferRepository
    {
        IEnumerable<AuctionOfferDtOs> GetAllAuctionOffer();
        Task<AuctionOfferDtOs?> GetAuctionOfferById(int id , CancellationToken cancellation);
        Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer , CancellationToken cancellation);
        Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer , CancellationToken cancellation);
        Task DeleteAuctionOffer(int id , CancellationToken cancellation);
    }
}
