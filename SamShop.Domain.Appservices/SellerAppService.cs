using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices
{
    public class SellerAppService : ISellerAppServices
    {
        protected readonly ISellerServices _sellerServices;

        public SellerAppService(ISellerServices sellerServices)
        {
            _sellerServices = sellerServices;
        }


        public IEnumerable<SellerDtOs> GetAllSeller()
        {
            return _sellerServices.GetAllSeller();
        }

        public async Task<SellerDtOs?> GetSellerById(int id, CancellationToken cancellation)
        {
            return await _sellerServices.GetSellerById(id, cancellation);
        }

        public async Task<int> AddSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            return await _sellerServices.AddSeller(Seller, cancellation);
        }

        public async Task UpdateSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            await _sellerServices.UpdateSeller(Seller, cancellation);
        }

        public async Task DeleteSeller(int id, CancellationToken cancellation)
        {
            await _sellerServices.DeleteSeller(id, cancellation);
        }

        public async Task<SellerDtOs> GetSellerByAppUserId(int appId, CancellationToken cancellation)
        {
            return await _sellerServices.GetSellerByAppUserId(appId, cancellation);
        }
    }
}
