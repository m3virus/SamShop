using SamShop.Domain.Core.Models.DtOs.WageDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IWageAppServices
    {
        IEnumerable<WageDtOs> GetAllWage();
        Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation);
        Task<int> AddWage(WageDtOs Wage, CancellationToken cancellation);
        Task UpdateWage(WageDtOs Wage, CancellationToken cancellation);
        Task DeleteWage(int id, CancellationToken cancellation);
    }
}
