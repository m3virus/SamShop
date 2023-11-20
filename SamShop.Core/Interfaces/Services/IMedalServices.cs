using SamShop.Domain.Core.Models.DtOs.MedalDtOs;
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
        IEnumerable<MedalDtOs> GetAllMedal();
        Task<MedalDtOs?> GetMedalById(int id, CancellationToken cancellation);
        Task<int> AddMedal(MedalDtOs Medal, CancellationToken cancellation);
        Task UpdateMedal(MedalDtOs Medal, CancellationToken cancellation);
        Task DeleteMedal(int id, CancellationToken cancellation);
    }
}
