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
            return _wageServices.GetAllWage().Where(x => x.IsDeleted != true).OrderBy(x => x.PayTime);
        }

        public async Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation)
        {
            return await _wageServices.GetWageById(id ,cancellation);
        }

        public async Task<int> AddWage(WageDtOs Wage, CancellationToken cancellation)
        {
            return await _wageServices.AddWage(Wage,cancellation);
        }

        public async Task UpdateWage(WageDtOs Wage, CancellationToken cancellation)
        {
            await _wageServices.UpdateWage(Wage,cancellation);
        }

        public async Task DeleteWage(int id, CancellationToken cancellation)
        {
            await _wageServices.DeleteWage(id ,cancellation);
        }
    }
}
