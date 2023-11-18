using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IWageRepository
    {
        IEnumerable<Wage> GetAllWage();
        Task<Wage?> GetWageById(int id, CancellationToken cancellation);
        Task<int> AddWage(Wage Wage, CancellationToken cancellation);
        Task UpdateWage(Wage Wage, CancellationToken cancellation);
        Task DeleteWage(int id, CancellationToken cancellation);
    }
}
