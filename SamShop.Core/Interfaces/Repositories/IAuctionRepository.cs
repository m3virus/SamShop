using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAllAuction();
        Task<Auction?> GetAuctionById(int id);
        Task AddAuction(Auction Auction);
        Task UpdateAuction(Auction Auction);
        Task DeleteAuction(int id);
    }
}
