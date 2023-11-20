using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<AdminDtOs> GetAllAdmin();
        Task<AdminDtOs?> GetAdminById(int id , CancellationToken cancellation);
        Task<int> AddAdmin(AdminDtOs Admin , CancellationToken cancellation);
        Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id , CancellationToken cancellation);
    }
}
