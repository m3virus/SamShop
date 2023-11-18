using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAuctionServices
    {
        IEnumerable<Auction> GetAllAuction();
        Task<Auction?> GetAuctionById(int id, CancellationToken cancellation);
        Task AddAuction(Auction Auction, CancellationToken cancellation);
        Task UpdateAuction(Auction Auction, CancellationToken cancellation);
        Task DeleteAuction(int id, CancellationToken cancellation);
    }
}
