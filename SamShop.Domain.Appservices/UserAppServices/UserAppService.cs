using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SamShop.Domain.Core.Interfaces.AppServices.UserAppServices;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices.UserAppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; 
        public UserAppService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(AppUser appUser, string password, AppRole appRole, CancellationToken cancellation)
        {
            var user = await _userManager.CreateAsync(appUser, password);
            await _userManager.AddToRoleAsync(appUser, appRole.ToString());
            return user;
        }

        public async Task<SignInResult> SignIn(AppUser appUser, string password, CancellationToken cancellation)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, password, true);
            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return SignInResult.Failed;
            }
        }
    }
}
