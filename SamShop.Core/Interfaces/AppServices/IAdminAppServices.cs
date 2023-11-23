using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IAdminAppServices
    {
        IEnumerable<AdminDtOs> GetAllAdmin();
        Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation);
        Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation);
        Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id, CancellationToken cancellation);
    }
}
