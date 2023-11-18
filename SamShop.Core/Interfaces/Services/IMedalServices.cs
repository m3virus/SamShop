using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IMedalServices
    {
        IEnumerable<Medal> GetAllMedal();
        Task<Medal?> GetMedalById(int id, CancellationToken cancellation);
        Task AddMedal(Medal Medal, CancellationToken cancellation);
        Task UpdateMedal(Medal Medal, CancellationToken cancellation);
        Task DeleteMedal(int id, CancellationToken cancellation);
    }
}
