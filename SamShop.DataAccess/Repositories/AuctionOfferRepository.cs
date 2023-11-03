using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class AuctionOfferRepository: IAuctionOfferRepository
    {
        protected readonly SamShopDbContext _context;

        public AuctionOfferRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAuctionOffer(AuctionOffer AuctionOffer)

        {
            AuctionOffer auctionOfferAdding = new AuctionOffer()
            {
                OfferValue = AuctionOffer.OfferValue,
                IsCanceled = false,

            };
            await _context.AuctionOffers.AddAsync(auctionOfferAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<AuctionOffer> GetAllAuctionOffer()
        {
            return _context.AuctionOffers;
        }



        public async Task<AuctionOffer?> GetAuctionOfferById(int id)
        {
            return await _context.AuctionOffers.FirstOrDefaultAsync(a => a.OfferId == id);

        }
        public async Task UpdateAuctionOffer(AuctionOffer AuctionOffer)
        {
            AuctionOffer? changeAuctionOffer = await _context.AuctionOffers.FirstOrDefaultAsync(p => p.OfferId == AuctionOffer.OfferId);
            if (changeAuctionOffer != null)
            {
                changeAuctionOffer.OfferValue = AuctionOffer.OfferValue;
                changeAuctionOffer.IsCanceled = AuctionOffer.IsCanceled;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAuctionOffer(int id)
        {
            AuctionOffer? removingaAuctionOffer = await _context.AuctionOffers.FirstOrDefaultAsync(p => p.OfferId == id);
            if (removingaAuctionOffer != null)
            {
                _context.Remove(removingaAuctionOffer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
