using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IAddressServices
    {
        IEnumerable<AddressDtOs> GetAllAddress();
        Task<AddressDtOs?> GetAddressById(int id, CancellationToken cancellation);
        Task<int> AddAddress(AddressDtOs Address, CancellationToken cancellation);
        Task UpdateAddress(AddressDtOs Address, CancellationToken cancellation);
        Task DeleteAddress(int id, CancellationToken cancellation);
    }
}
