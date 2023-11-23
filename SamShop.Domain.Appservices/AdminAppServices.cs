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
            throw new NotImplementedException();
        }

        public async Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAdmin(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
