using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices.SellerAppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices.SellerAppServices
{
    public class SellerAppService : ISellerAppServices
    {
        protected readonly ISellerServices _sellerServices;

        public SellerAppService(ISellerServices sellerServices)
        {
            _sellerServices = sellerServices;
        }

        public async Task AddSeller(Seller Seller, CancellationToken cancellation)
        {
            await _sellerServices.AddSeller(Seller, cancellation);
        }
    }
}
