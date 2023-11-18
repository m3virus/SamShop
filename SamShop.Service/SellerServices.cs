using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
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

        public IEnumerable<Seller> GetAllSeller()
        {
            throw new NotImplementedException();
        }

        public Task<Seller?> GetSellerById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task AddSeller(Seller Seller, CancellationToken cancellation)
        {
            await _sellerRepository.AddSeller(Seller, cancellation);
        }

        public Task UpdateSeller(Seller Seller, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSeller(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
