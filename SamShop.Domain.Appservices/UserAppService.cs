﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices
{
    public class UserAppService : IUserAppServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserAppService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(AppUser appUser, string password, string appRole, CancellationToken cancellation)
        {
            
            var userResult = await _userManager.CreateAsync(appUser, password);
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            await _userManager.AddToRoleAsync(user, appRole);
            return userResult;
        }

        public async Task<SignInResult> SignIn(string Email, string password, CancellationToken cancellation)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if (User != null)
            {
                var check = await _signInManager.PasswordSignInAsync(User.UserName, password, false, false);
                return check;
            }
            else
            {
                return SignInResult.Failed;
            }
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
