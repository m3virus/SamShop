using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAuctionOfferServices
    {
        IEnumerable<AuctionOffer> GetAllAuctionOffer();
        Task<AuctionOffer?> GetAuctionOfferById(int id, CancellationToken cancellation);
        Task AddAuctionOffer(AuctionOffer AuctionOffer, CancellationToken cancellation);
        Task UpdateAuctionOffer(AuctionOffer AuctionOffer, CancellationToken cancellation);
        Task DeleteAuctionOffer(int id, CancellationToken cancellation);
    }
}
