using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class AuctionRepository:IAuctionRepository
    {
        protected readonly SamShopDbContext _context;

        public AuctionRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAuction(Auction Auction , CancellationToken cancellation)

        {
            Auction AuctionAdding = new Auction()
            {
                AuctionTitle = Auction.AuctionTitle,
                TheLowestOffer = Auction.TheLowestOffer,
                StartTime = Auction.StartTime,
                EndTime = Auction.EndTime,

            };
            await _context.Auctions.AddAsync(AuctionAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Auction> GetAllAuction()
        {
            return _context.Auctions;
        }



        public async Task<Auction?> GetAuctionById(int id , CancellationToken cancellation)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == id, cancellation);

        }
        public async Task UpdateAuction(Auction Auction, CancellationToken cancellation)
        {
            Auction? changeAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == Auction.AuctionId, cancellation);
            if (changeAuction != null)
            {
                changeAuction.AuctionTitle = Auction.AuctionTitle;
                changeAuction.TheLowestOffer = Auction.TheLowestOffer;
                changeAuction.StartTime = Auction.StartTime;
                changeAuction.EndTime = Auction.EndTime;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAuction(int id , CancellationToken cancellation)
        {
            Auction? removingAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == id, cancellation);
            if (removingAuction != null)
            {
                _context.Remove(removingAuction);
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
