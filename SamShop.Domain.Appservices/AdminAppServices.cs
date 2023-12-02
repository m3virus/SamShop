using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;

namespace SamShop.Domain.Appservices
{
    public class AdminAppServices : IAdminAppServices
    {
        protected readonly IAdminServices _adminServices;

        public AdminAppServices(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }


        public IEnumerable<AdminDtOs> GetAllAdmin()
        {
            return _adminServices.GetAllAdmin();
        }

        public async Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation)
        {
            return await _adminServices.GetAdminById(id, cancellation);
        }

        public async Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            return await _adminServices.AddAdmin(Admin, cancellation);
        }

        public async Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            await _adminServices.UpdateAdmin(Admin, cancellation);
        }

        public async Task DeleteAdmin(int id, CancellationToken cancellation)
        {
            await _adminServices.DeleteAdmin(id, cancellation);
        }

        public async Task<AdminDtOs> GetAdminByAppUserId(int appId, CancellationToken cancellation)
        {
            return await _adminServices.GetAdminByAppUserId(appId, cancellation);
        }
    }
}
