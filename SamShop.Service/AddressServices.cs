using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class AddressServices : IAddressServices
    {
        protected readonly IAddressRepository _addressRepository;
        public AddressServices(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        #region RepoCRUD

        public IEnumerable<AddressDtOs> GetAllAddress()
        {
            return _addressRepository.GetAllAddress();
        }

        public async Task<AddressDtOs?> GetAddressById(int id, CancellationToken cancellation)
        {
            return await _addressRepository.GetAddressById(id, cancellation);
        }

        public async Task<int> AddAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            return await _addressRepository.AddAddress(Address, cancellation);
        }

        public async Task UpdateAddress(AddressDtOs Address, CancellationToken cancellation)
        {
            await _addressRepository.UpdateAddress(Address, cancellation);

        }

        public async Task DeleteAddress(int id, CancellationToken cancellation)
        {
            await _addressRepository.DeleteAddress(id, cancellation);
        }

        #endregion

    }
}
