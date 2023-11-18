using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;

        public AdminUserController(UserManager<AppUser> userManager, ISellerRepository sellerRepository, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //return View(_userManager.Users);
            return Content("hello");
        }

        public async Task<IActionResult> Detail(int Id , CancellationToken cancellation)
        {
            var result = _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken: cancellation);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task Edit(AppUser appUser,string password , CancellationToken cancellation)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUser.Id, cancellation);
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            if (result != null)
            {
                result.PasswordHash = passwordHasher.HashPassword(appUser, password);
                await _userManager.UpdateAsync(result);
            }
        }

        public async Task Delete(int Id, CancellationToken cancellation)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x =>x.Id == Id, cancellation);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeleteTime = DateTime.Now;
                await _userManager.UpdateAsync(result);
            }
        }
    }
}
