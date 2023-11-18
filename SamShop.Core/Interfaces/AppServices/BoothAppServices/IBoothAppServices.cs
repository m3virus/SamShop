using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices
{
    public interface IBoothAppServices
    {
        Task AddBooth(Booth Booth, CancellationToken cancellation);
    }
}
