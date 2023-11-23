using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IAuctionAppServices
    {
        IEnumerable<AuctionDtOs> GetAllAuction();
        Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation);
        Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation);
        Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation);
        Task DeleteAuction(int id, CancellationToken cancellation);
    }
}
