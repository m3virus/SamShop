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

        public AuctionAppServices(IAuctionServices auctionServices)
        {
            _auctionServices = auctionServices;
        }


        public IEnumerable<AuctionDtOs> GetAllAuction()
        {
            throw new NotImplementedException();
        }

        public async Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAuction(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
