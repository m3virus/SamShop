using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;

namespace SamShop.Domain.Appservices
{
    public class AuctionOfferAppServices : IAuctionOfferAppServices
    {
        protected readonly IAuctionOfferServices _auctionOfferServices;

        public AuctionOfferAppServices(IAuctionOfferServices auctionOfferServices)
        {
            _auctionOfferServices = auctionOfferServices;
        }


        public IEnumerable<AuctionOfferDtOs> GetAllAuctionOffer()
        {
           return _auctionOfferServices.GetAllAuctionOffer();
        }

        public async Task<AuctionOfferDtOs?> GetAuctionOfferById(int id, CancellationToken cancellation)
        {
            return await _auctionOfferServices.GetAuctionOfferById(id, cancellation);
        }

        public async Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            return await _auctionOfferServices.AddAuctionOffer(AuctionOffer, cancellation);
        }

        public async Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            await _auctionOfferServices.UpdateAuctionOffer(AuctionOffer, cancellation);
        }

        public async Task DeleteAuctionOffer(int id, CancellationToken cancellation)
        {
            await _auctionOfferServices.DeleteAuctionOffer(id, cancellation);
        }
    }
}
