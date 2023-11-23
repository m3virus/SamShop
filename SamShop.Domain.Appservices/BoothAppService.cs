using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices
{
    public class BoothAppService : IBoothAppServices
    {
        protected readonly IBoothServices _boothServices;
        protected readonly IAddressServices _addressServices;

        public BoothAppService(IBoothServices boothServices, IAddressServices addressServices)
        {
            _boothServices = boothServices;
            _addressServices = addressServices;
        }


        public Task AddBooth(Booth Booth, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoothDtOs> GetAllBooth()
        {
            throw new NotImplementedException();
        }

        public Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBooth(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
