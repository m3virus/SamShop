using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
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

        public IEnumerable<Booth> GetAllBooth()
        {
            throw new NotImplementedException();
        }

        public Task<Booth?> GetBoothById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddBooth(Booth Booth, CancellationToken cancellation)
        {
            await _boothRepository.AddBooth(Booth, cancellation);
            return Booth.BoothId;
        }

        public Task UpdateBooth(Booth Booth, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBooth(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
