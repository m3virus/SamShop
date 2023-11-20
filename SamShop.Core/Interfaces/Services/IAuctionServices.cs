using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAuctionServices
    {
        IEnumerable<AuctionDtOs> GetAllAuction();
        Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation);
        Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation);
        Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation);
        Task DeleteAuction(int id, CancellationToken cancellation);
    }
}
