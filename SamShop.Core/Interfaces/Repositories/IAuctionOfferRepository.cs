using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
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
