using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices
{
    public class AddressAppService : IAddressAppServices
    {
        protected readonly IAddressServices _addressServices;

        public AddressAppService(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }


        public IEnumerable<AddressDtOs> GetAllAddress()
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDtOs?> GetAddressById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAddress(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }

}
