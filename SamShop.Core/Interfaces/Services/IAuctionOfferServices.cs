using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAuctionOfferServices
    {
        IEnumerable<AuctionOfferDtOs> GetAllAuctionOffer();
        Task<AuctionOfferDtOs?> GetAuctionOfferById(int id, CancellationToken cancellation);
        Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation);
        Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation);
        Task DeleteAuctionOffer(int id, CancellationToken cancellation);
    }
}
