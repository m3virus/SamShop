using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs;

namespace SamShop.Domain.Core.Interfaces.AppServices.AddressAppServices
{
    public interface IAddressAppService
    {
        Task AddAddress(AddressDtOs Address, CancellationToken cancellation);
    }
}
