﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.SellerAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.UserAppServices;
using SamShop.Domain.Core.Models.DtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Identity.Models;

namespace SamShop.endpoint.Areas.Identity.Controllers
{
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
            //if (ModelState.IsValid)
            //{
            //    var registerAppUser = new AppUser()
            //    {
                    
            //    };

            //    var AppUserRegisterResult = await _userAppService.Register(registerAppUser ,sellerRegister.password ,"Seller", cancellation);
                
            //    if (AppUserRegisterResult.Succeeded)
            //    {
            //        var registerBoothAddress = new AddressDtOs()
            //        {

            //        };
            //        var registerBooth = new BoothDtOs()
            //        {

            //        };
            //        await _boothAppService.Create(registerBooth , registerBoothAddress , cancellation);

            //        var registerSeller = new SellerDtOs()
            //        {

            //        };
            //        var registerSellerAddress = new AddressDtOs()
            //        {

            //        };
            //        await _sellerAppService.create(registerSeller ,  registerSellerAddress , cancellation);

            //    }
            //}
            return View();
        }

        public async Task<IActionResult> CustomerRegister(CustomerRegisterViewModel customerRegister)
        {
            if (ModelState.IsValid)
            {
                //var result = await _userAppService.Register();
                //if (result)
                //{

                //}
            }
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel login)
        {
            return View();
        }
    }
}
