using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using SamShop.Controllers;
using SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.SellerAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.UserAppServices;
using SamShop.Domain.Core.Models.DtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Identity.Models;

namespace SamShop.endpoint.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class IdentityController : Controller
    {


        protected readonly IUserAppService _userAppService;
        protected readonly IBoothAppServices _boothAppService;
        protected readonly ISellerAppServices _sellerAppService;
        public IdentityController(IUserAppService userAppService, IBoothAppServices boothAppService, ISellerAppServices sellerAppService)
        {
            _userAppService = userAppService;
            _boothAppService = boothAppService;
            _sellerAppService = sellerAppService;
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SellerRegister(SellerRegisterViewModel sellerRegister , CancellationToken cancellation)
        {
            
            return View();
        }

        public async Task<IActionResult> CustomerRegister(CustomerRegisterViewModel customerRegister)
        {
            if (ModelState.IsValid)
            {
            }
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel login, CancellationToken cancellation , string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _userAppService.SignIn(login.Email , login.Password , cancellation);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index" , "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(login);
                }
            }
            return View(login);
            
        }
    }
}
