using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ISellerServices
    {
        IEnumerable<SellerDtOs> GetAllSeller();
        Task<SellerDtOs?> GetSellerById(int id, CancellationToken cancellation);
        Task<int> AddSeller(SellerDtOs Seller, CancellationToken cancellation);
        Task UpdateSeller(SellerDtOs Seller, CancellationToken cancellation);
        Task DeleteSeller(int id, CancellationToken cancellation);
    }
}
