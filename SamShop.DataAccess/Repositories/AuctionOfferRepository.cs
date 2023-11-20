using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
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

        public async Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)

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
            return auctionOfferAdding.OfferId;
        }

        public IEnumerable<AuctionOfferDtOs> GetAllAuctionOffer()
        {
            var AuctionOffers = _context.AuctionOffers.AsNoTracking();
            var AuctionOfferDtOs = new List<AuctionOfferDtOs>();

            foreach (var a in AuctionOffers)
            {
                var AuctionOffer = new AuctionOfferDtOs()
                {
                    OfferValue = a.OfferValue,
                    AuctionId = a.AuctionId,
                    CustomerId = a.CustomerId,
                    IsCanceled = a.IsCanceled,
                    IsAccept = a.IsAccept,
                    OfferTime = a.OfferTime,
                    CancelTime = a.CancelTime,
                };
                AuctionOfferDtOs.Add(AuctionOffer);
            }

            return AuctionOfferDtOs;
        }



        public async Task<AuctionOfferDtOs?> GetAuctionOfferById(int id, CancellationToken cancellation)
        {
            var AuctionOffer = await _context.AuctionOffers.AsNoTracking()
                .FirstOrDefaultAsync(a => a.OfferId == id, cancellation);

            var AuctionOfferById = new AuctionOfferDtOs()
            {
                OfferValue = AuctionOffer.OfferValue,
                AuctionId = AuctionOffer.AuctionId,
                CustomerId = AuctionOffer.CustomerId,
                IsCanceled = AuctionOffer.IsCanceled,
                IsAccept = AuctionOffer.IsAccept,
                OfferTime = AuctionOffer.OfferTime,
                CancelTime = AuctionOffer.CancelTime,
            };
            return AuctionOfferById;

        }
        public async Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
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
