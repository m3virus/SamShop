using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAdminServices
    {
        IEnumerable<AdminDtOs> GetAllAdmin();
        Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation);
        Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation);
        Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id, CancellationToken cancellation);
    }
}
