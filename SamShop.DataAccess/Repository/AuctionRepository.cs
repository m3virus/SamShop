using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repository
{
    internal class AuctionRepository:IAuctionRepository
    {
        protected readonly SamShopDbContext _context;

        public AuctionRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAuction(Auction Auction)

        {
            Auction AuctionAdding = new Auction()
            {
                AuctionTitle = Auction.AuctionTitle,
                TheLowestOffer = Auction.TheLowestOffer,
                StartTime = Auction.StartTime,
                EndTime = Auction.EndTime,

            };
            await _context.Auctions.AddAsync(AuctionAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Auction> GetAllAuction()
        {
            return _context.Auctions;
        }



        public async Task<Auction?> GetAuctionById(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == id);

        }
        public async Task UpdateAuction(Auction Auction)
        {
            Auction? changeAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == Auction.AuctionId);
            if (changeAuction != null)
            {
                changeAuction.AuctionTitle = Auction.AuctionTitle;
                changeAuction.TheLowestOffer = Auction.TheLowestOffer;
                changeAuction.StartTime = Auction.StartTime;
                changeAuction.EndTime = Auction.EndTime;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAuction(int id)
        {
            Auction? removingaAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == id);
            if (removingaAuction != null)
            {
                _context.Remove(removingaAuction);
            }
            await _context.SaveChangesAsync();
        }
    }
}
