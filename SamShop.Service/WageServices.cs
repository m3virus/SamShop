using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class WageServices:IWageServices
    {
        protected readonly IWageRepository _wageRepository;

        public WageServices(IWageRepository wageRepository)
        {
            _wageRepository = wageRepository;
        }

        public IEnumerable<WageDtOs> GetAllWage()
        {
            return _wageRepository.GetAllWage();
        }

        public async Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation)
        {
            return await _wageRepository.GetWageById(id, cancellation);
        }

        public async Task<int> AddWage(WageDtOs Wage, CancellationToken cancellation)
        {
            return await _wageRepository.AddWage(Wage, cancellation);
        }

        public async Task UpdateWage(WageDtOs Wage, CancellationToken cancellation)
        {
            await _wageRepository.UpdateWage(Wage, cancellation);
        }

        public async Task DeleteWage(int id, CancellationToken cancellation)
        {
            await _wageRepository.DeleteWage(id, cancellation);
        }
    }
}
