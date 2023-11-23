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
            throw new NotImplementedException();
        }

        public async Task<SellerDtOs?> GetSellerById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSeller(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
