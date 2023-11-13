using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class AuctionOfferRepository: IAuctionOfferRepository
    {
        protected readonly SamShopDbContext _context;

        public AuctionOfferRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAuctionOffer(AuctionOffer AuctionOffer, CancellationToken cancellation)

        {
            AuctionOffer auctionOfferAdding = new AuctionOffer()
            {
                OfferValue = AuctionOffer.OfferValue,
                AuctionId = AuctionOffer.AuctionId,
                CustomerId = AuctionOffer.CustomerId,
                IsCanceled = false,
                IsAccept = false,
                OfferTime = DateTime.Now,
                CancelTime = null,
                

            };
            await _context.AuctionOffers.AddAsync(auctionOfferAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<AuctionOffer> GetAllAuctionOffer()
        {
            return _context.AuctionOffers;
        }



        public async Task<AuctionOffer?> GetAuctionOfferById(int id, CancellationToken cancellation)
        {
            return await _context.AuctionOffers.FirstOrDefaultAsync(a => a.OfferId == id, cancellation);

        }
        public async Task UpdateAuctionOffer(AuctionOffer AuctionOffer, CancellationToken cancellation)
        {
            AuctionOffer? changeAuctionOffer = await _context.AuctionOffers.FirstOrDefaultAsync(p => p.OfferId == AuctionOffer.OfferId, cancellation);
            if (changeAuctionOffer != null)
            {
                changeAuctionOffer.IsAccept = AuctionOffer.IsAccept;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAuctionOffer(int id, CancellationToken cancellation)
        {
            AuctionOffer? removingAuctionOffer = await _context.AuctionOffers.FirstOrDefaultAsync(p => p.OfferId == id, cancellation);
            if (removingAuctionOffer != null)
            {
                removingAuctionOffer.IsCanceled = true;
                removingAuctionOffer.CancelTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
