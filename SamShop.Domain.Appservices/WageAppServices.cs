using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;

namespace SamShop.Domain.Appservices
{
    public class WageAppServices : IWageAppServices
    {
        protected readonly IWageServices _wageServices;

        public WageAppServices(IWageServices wageServices)
        {
            _wageServices = wageServices;
        }

        public IEnumerable<WageDtOs> GetAllWage()
        {
            throw new NotImplementedException();
        }

        public async Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddWage(WageDtOs Wage, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateWage(WageDtOs Wage, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWage(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
