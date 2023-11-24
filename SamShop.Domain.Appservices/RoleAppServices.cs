using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Appservices
{
    public class RoleAppServices : IRoleAppServices
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly RoleManager<AppRole> _roleManager;
        public RoleAppServices(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IList<string>> GetUserRole(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            var role = await _userManager.GetRolesAsync(user);

            return role;

        }
    }
}
