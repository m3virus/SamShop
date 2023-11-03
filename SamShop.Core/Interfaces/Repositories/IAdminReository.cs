using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAdminReository
    {
        IEnumerable<Admin> GetAllAdmin(CancellationToken cancellation);
        Task<Admin?> GetAdminById(int id , CancellationToken cancellation);
        Task AddAdmin(Admin Admin , CancellationToken cancellation);
        Task UpdateAdmin(Admin Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id , CancellationToken cancellation);
    }
}
