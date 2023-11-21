using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices.BoothAppServices
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
    }
}
