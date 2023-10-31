using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetAllSeller();
        Task<Seller?> GetSellerById(int id);
        Task AddSeller(Seller Seller);
        Task UpdateSeller(Seller Seller);
        Task DeleteSeller(int id);
    }
}
