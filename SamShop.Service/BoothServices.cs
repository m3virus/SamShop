using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class BoothServices : IBoothServices
    {
        protected readonly IBoothRepository _boothRepository;

        public BoothServices(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
        }

        public IEnumerable<BoothDtOs> GetAllBooth()
        {
            return _boothRepository.GetAllBooth();
        }

        public async Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation)
        {
            return await _boothRepository.GetBoothById(id, cancellation);
        }

        public async Task<int> AddBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            return await _boothRepository.AddBooth(Booth, cancellation);
        }

        public async Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            await _boothRepository.UpdateBooth(Booth, cancellation);
        }

        public async Task DeleteBooth(int id, CancellationToken cancellation)
        {
            await _boothRepository.DeleteBooth(id, cancellation);
        }
    }
}
