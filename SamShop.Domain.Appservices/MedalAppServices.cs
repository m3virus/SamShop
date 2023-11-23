using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.MedalDtOs;

namespace SamShop.Domain.Appservices
{
    public class MedalAppServices : IMedalAppServices
    {
        protected readonly IMedalServices _medalServices;

        public MedalAppServices(IMedalServices medalServices)
        {
            _medalServices = medalServices;
        }

        public IEnumerable<MedalDtOs> GetAllMedal()
        {
            throw new NotImplementedException();
        }

        public async Task<MedalDtOs?> GetMedalById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddMedal(MedalDtOs Medal, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMedal(MedalDtOs Medal, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMedal(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
