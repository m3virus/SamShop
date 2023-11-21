using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ISellerRepository _sellerRepository;
        protected readonly ICustomerRepository _customerRepository;
        protected readonly SamShopDbContext _context;

        public AdminUserController(UserManager<AppUser> userManager, ISellerRepository sellerRepository, ICustomerRepository customerRepository, SamShopDbContext context)
        {
            _userManager = userManager;
            _sellerRepository = sellerRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(_userManager.Users.OrderBy(x => x.IsDeleted));
            
        }

        //public async Task<IActionResult> Detail(int Id , CancellationToken cancellation)
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id, cancellation);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return View(user);
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Edit(int Id, CancellationToken cancellation)
        {
            var result = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellation);
            
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser appUser, CancellationToken cancellation)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUser.Id, cancellation);
            if (result != null) {
                result.FirstName = appUser.FirstName;
                result.LastName = appUser.LastName;
                result.Email = appUser.Email;
                result.UserName = appUser.UserName;
                result.Birthday = appUser.Birthday;
                await _userManager.UpdateAsync(result);
            }

            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id, CancellationToken cancellation)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x =>x.Id == Id, cancellation);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeleteTime = DateTime.Now;
                await _userManager.UpdateAsync(result);
            }
            return RedirectToAction("Index");
        }
    }
}
