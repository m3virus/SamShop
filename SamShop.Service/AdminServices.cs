using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class AdminServices: IAdminServices
    {
        protected readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        public IEnumerable<AdminDtOs> GetAllAdmin()
        {
            return _adminRepository.GetAllAdmin();
        }

        public async  Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation)
        {
            return await _adminRepository.GetAdminById(id, cancellation);
        }

        public async Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            return await _adminRepository.AddAdmin(Admin, cancellation);
        }

        public async Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            await _adminRepository.UpdateAdmin(Admin, cancellation);
        }

        public async Task DeleteAdmin(int id, CancellationToken cancellation)
        {
            await _adminRepository.DeleteAdmin(id, cancellation);
        }

        public async Task<AdminDtOs> GetAdminByAppUserId(int appId, CancellationToken cancellation)
        {
            return await _adminRepository.GetAdminByAppUserId(appId, cancellation);
        }
    }
}
