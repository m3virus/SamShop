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


        public IEnumerable<BoothDtOs> GetAllBooth()
        {
            return _boothServices.GetAllBooth().Where(x => x.IsDeleted != true);
        }

        public async Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation)
        {
            return await _boothServices.GetBoothById(id, cancellation);
        }

        public async Task<int> AddBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            return await _boothServices.AddBooth(Booth , cancellation);
        }

        public async Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            await _boothServices.UpdateBooth(Booth, cancellation);
        }

        public async Task DeleteBooth(int id, CancellationToken cancellation)
        {
            await _boothServices.DeleteBooth(id, cancellation);
        }
    }
}
