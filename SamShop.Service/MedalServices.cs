using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.MedalDtOs;

namespace SamShop.Domain.Service
{
    public class MedalServices : IMedalServices
    {
        protected readonly IMedalRepository _MedalRepository;

        public MedalServices(IMedalRepository MedalRepository)
        {
            _MedalRepository = MedalRepository;
        }

        public IEnumerable<MedalDtOs> GetAllMedal()
        {
            return _MedalRepository.GetAllMedal();
        }

        public async Task<MedalDtOs?> GetMedalById(int id, CancellationToken cancellation)
        {
            return await _MedalRepository.GetMedalById(id, cancellation);
        }

        public async Task<int> AddMedal(MedalDtOs Medal, CancellationToken cancellation)
        {
            return await _MedalRepository.AddMedal(Medal, cancellation);
        }

        public async Task UpdateMedal(MedalDtOs Medal, CancellationToken cancellation)
        {
            await _MedalRepository.UpdateMedal(Medal, cancellation);
        }

        public async Task DeleteMedal(int id, CancellationToken cancellation)
        {
            await _MedalRepository.DeleteMedal(id, cancellation);
        }
    }
}
