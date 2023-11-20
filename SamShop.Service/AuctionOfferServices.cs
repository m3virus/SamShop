using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class AuctionOfferServices :IAuctionOfferServices
    {
        protected readonly IAuctionOfferRepository _auctionOfferRepository;

        public AuctionOfferServices(IAuctionOfferRepository auctionOfferRepository)
        {
            _auctionOfferRepository = auctionOfferRepository;
        }


        public IEnumerable<AuctionOfferDtOs> GetAllAuctionOffer()
        {
            return _auctionOfferRepository.GetAllAuctionOffer();
        }

        public async Task<AuctionOfferDtOs?> GetAuctionOfferById(int id, CancellationToken cancellation)
        {
            return await _auctionOfferRepository.GetAuctionOfferById(id, cancellation);
        }

        public Task<int> AddAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            return _auctionOfferRepository.AddAuctionOffer(AuctionOffer, cancellation);
        }

        public Task UpdateAuctionOffer(AuctionOfferDtOs AuctionOffer, CancellationToken cancellation)
        {
            return _auctionOfferRepository.UpdateAuctionOffer(AuctionOffer, cancellation);
        }

        public Task DeleteAuctionOffer(int id, CancellationToken cancellation)
        {
            return _auctionOfferRepository.DeleteAuctionOffer(id, cancellation);
        }
    }
}
