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
            throw new NotImplementedException();
        }

        public async Task<AuctionOfferDtOs?> GetAuctionOfferById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAuctionOffer(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
