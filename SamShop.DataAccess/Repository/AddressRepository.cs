using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Application.EntityFramework.DBContext;
using SamShop.Domain.Core.Interfaces.IRepository;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Application.DataAccess.Repository
{
    internal class AddressRepository : IAddressRepository 
    {
        protected readonly SamShopDbContext _context;

        public AddressRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAddress(Address address)

        {
            Address addressAdding = new Address()
            {
                State = address.State,
                City = address.City,
                Street = address.Street,
                Alley = address.Alley,
                ExtraPart = address.ExtraPart,
                PostCode = address.PostCode
            };
            await _context.Addresses.AddAsync(addressAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Address> GetAllAddress()
        {
            return _context.Addresses;
        }

       

        public async Task<Address?> getAddressById(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);

        }
        public async Task UpdateAddress(Address address)
        {
            Address? changeAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == address.AddressId);
            if (changeAddress != null)
            {
                changeAddress.State = address.State;
                changeAddress.City = address.City;
                changeAddress.Street = address.Street;
                changeAddress.Alley = address.Alley;
                changeAddress.ExtraPart = address.ExtraPart;
                changeAddress.PostCode = address.PostCode;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAddress(int id)
        {
            Address? removingaAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == id);
            if (removingaAddress != null)
            {
                _context.Remove(removingaAddress);
            }
            await _context.SaveChangesAsync();
        }
    }
}
