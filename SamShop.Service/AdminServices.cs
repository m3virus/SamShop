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
            throw new NotImplementedException();
        }

        public Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdmin(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
