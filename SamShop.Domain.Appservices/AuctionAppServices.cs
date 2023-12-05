using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;

namespace SamShop.Domain.Appservices
{
    public class AuctionAppServices: IAuctionAppServices
    {
        protected readonly IAuctionServices _auctionServices;
        protected readonly IJobServices _jobServices;

        public AuctionAppServices(IAuctionServices auctionServices, IJobServices jobServices)
        {
            _auctionServices = auctionServices;
            _jobServices = jobServices;
        }


        public IEnumerable<AuctionDtOs> GetAllAuction()
        {
            return _auctionServices.GetAllAuction();
        }

        public async Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation)
        {
            return await _auctionServices.GetAuctionById(id, cancellation);
        }

        public async Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            var auctionId = await _auctionServices.AddAuction(Auction, cancellation);
            _jobServices.AddNewJub<IAuctionServices>(a => a.StartAuction(auctionId, cancellation), Auction.StartTime);
            _jobServices.AddNewJub<IAuctionServices>(a => a.EndAuction(auctionId, cancellation), Auction.EndTime);
            return auctionId;
        }

        public async Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            await _auctionServices.UpdateAuction(Auction, cancellation);
        }

        public async Task DeleteAuction(int id, CancellationToken cancellation)
        {
            await _auctionServices.DeleteAuction(id, cancellation);
        }
    }
}
