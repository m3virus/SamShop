using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices.AddressAppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.AppServices.AddressAppServices
{
    public class AddressAppService : IAddressAppService
    {
        protected readonly IAddressServices _addressServices;

        public AddressAppService(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }
        public async Task AddAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            await _addressServices.AddAddress(Address , cancellation);
        }
    }
}
