using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.AppServices.UserAppServices
{
    public interface IUserAppService
    {
        Task <IdentityResult> Register (AppUser appUser, string password ,AppRole appRole , CancellationToken cancellation);
        Task<SignInResult> SignIn(AppUser appUser, string password , CancellationToken cancellation);
    }
}
