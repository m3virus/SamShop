using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class AuctionServices:IAuctionServices
    {
        protected readonly IAuctionRepository _auctionRepository;

        public AuctionServices(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }


        public async Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuctionById(id, cancellation);
        }

        public async Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            return await _auctionRepository.AddAuction(Auction, cancellation);
        }

        public async Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
             await _auctionRepository.UpdateAuction(Auction, cancellation);
        }

        public async Task DeleteAuction(int id, CancellationToken cancellation)
        { 
            await _auctionRepository.DeleteAuction(id, cancellation);
        }

        IEnumerable<AuctionDtOs> IAuctionServices.GetAllAuction()
        {
            return _auctionRepository.GetAllAuction();
        }

    }
}
