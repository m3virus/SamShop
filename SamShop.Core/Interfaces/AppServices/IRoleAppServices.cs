using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IRoleAppServices
    {
        Task<IList<string>> GetUserRole(string Email);
    }
}
