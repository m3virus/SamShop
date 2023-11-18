using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ISellerServices
    {
        IEnumerable<Seller> GetAllSeller();
        Task<Seller?> GetSellerById(int id, CancellationToken cancellation);
        Task AddSeller(Seller Seller, CancellationToken cancellation);
        Task UpdateSeller(Seller Seller, CancellationToken cancellation);
        Task DeleteSeller(int id, CancellationToken cancellation);
    }
}
