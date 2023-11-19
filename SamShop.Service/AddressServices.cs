using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AddressDtos;

namespace SamShop.Domain.Service
{
    public class AddressServices : IAddressServices
    {
        protected readonly IAddressRepository _addressRepository;
        public AddressServices(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IEnumerable<AddressDtOs> GetAllAddress()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDtOs?> GetAddressById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task AddAddress(AddressDtOs Address, CancellationToken cancellation)
        {

            await _addressRepository.AddAddress(Address , cancellation);
        }

        public Task UpdateAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddress(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
