using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class SellerServices : ISellerServices

    {
        protected readonly ISellerRepository _sellerRepository;

        public SellerServices(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public IEnumerable<SellerDtOs> GetAllSeller()
        {
            return _sellerRepository.GetAllSeller();
        }

        public async Task<SellerDtOs?> GetSellerById(int id, CancellationToken cancellation)
        {
            return await _sellerRepository.GetSellerById(id, cancellation);
        }

        public async Task<int> AddSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            var sellerId = await _sellerRepository.AddSeller(Seller, cancellation);
            return sellerId;
        }

        public async Task UpdateSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            await _sellerRepository.UpdateSeller(Seller, cancellation);
        }

        public async Task DeleteSeller(int id, CancellationToken cancellation)
        {
            await _sellerRepository.DeleteSeller(id, cancellation);
        }

        public async Task<SellerDtOs> GetSellerByAppUserId(int appId, CancellationToken cancellation)
        {
            return await _sellerRepository.GetSellerByAppUserId(appId, cancellation);
        }
    }
}
