using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository 
    {
        protected readonly SamShopDbContext _context;

        public AddressRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAddress(AddressDtOs address, CancellationToken cancellation)
        {
            Address addressAdding = new Address()
            {
                State = address.State,
                City = address.City,
                Street = address.Street,
                Alley = address.Alley,
                ExtraPart = address.ExtraPart,
                PostCode = address.PostCode,
                IsDeleted = false
                
            };
            await _context.Addresses.AddAsync(addressAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return addressAdding.AddressId;
           
        }

        public IEnumerable<AddressDtOs> GetAllAddress()
        {
            var addresses = _context.Addresses;
            var addressDtos = new List<AddressDtOs>();

            foreach (var address in addresses)
            {
                var addressDto = new AddressDtOs()
                {
                    State = address.State,
                    City = address.City,
                    Street = address.Street,
                    Alley = address.Alley,
                    ExtraPart = address.ExtraPart,
                    PostCode = address.PostCode,
                };
                addressDtos.Add(addressDto);
            }

            return addressDtos;
        }



        public async Task<AddressDtOs?> GetAddressById(int id, CancellationToken cancellation)
        {
            var addressById = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == id && x.IsDeleted != true, cancellation);
            var addressService = new AddressDtOs()
            {
                State = addressById.State,
                City = addressById.City,
                Street = addressById.Street,
                Alley = addressById.Alley,
                ExtraPart = addressById.ExtraPart,
                PostCode = addressById.PostCode,
            };
            return addressService;

        }
        public async Task UpdateAddress(AddressDtOs address, CancellationToken cancellation)
        {
            Address? changeAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == address.AddressId, cancellation);
            if (changeAddress != null)
            {
                changeAddress.State = address.State;
                changeAddress.City = address.City;
                changeAddress.Street = address.Street;
                changeAddress.Alley = address.Alley;
                changeAddress.ExtraPart = address.ExtraPart;
                changeAddress.PostCode = address.PostCode;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAddress(int id, CancellationToken cancellation)
        {
            Address? removingAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == id, cancellation);
            if (removingAddress != null)
            {
                removingAddress.IsDeleted = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
