using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IWageServices
    {
        IEnumerable<WageDtOs> GetAllWage();
        Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation);
        Task<int> AddWage(WageDtOs Wage, CancellationToken cancellation);
        Task UpdateWage(WageDtOs Wage, CancellationToken cancellation);
        Task DeleteWage(int id, CancellationToken cancellation);
    }
}
