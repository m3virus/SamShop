using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices.SellerAppServices
{
    public interface ISellerAppServices
    {
        Task AddSeller(Seller Seller, CancellationToken cancellation);
    }
}
