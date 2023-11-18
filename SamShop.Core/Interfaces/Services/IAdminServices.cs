using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAdminServices
    {
        IEnumerable<Admin> GetAllAdmin();
        Task<Admin?> GetAdminById(int id, CancellationToken cancellation);
        Task AddAdmin(Admin Admin, CancellationToken cancellation);
        Task UpdateAdmin(Admin Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id, CancellationToken cancellation);
    }
}
