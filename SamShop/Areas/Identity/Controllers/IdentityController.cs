using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using SamShop.Controllers;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
using SamShop.Domain.Core.Models.DtOs.PictureDtOs;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.Domain.Core.Models.Entities;

using SamShop.endpoint.Areas.Identity.Models;

namespace SamShop.endpoint.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class IdentityController : Controller
    {
        protected readonly RoleManager<AppRole> _roleManager;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IUserAppServices _userAppService;
        protected readonly IBoothAppServices _boothAppService;
        protected readonly ISellerAppServices _sellerAppService;
        protected readonly ICustomerAppServices _customerAppService;
        protected readonly IRoleAppServices _roleAppServices;
        protected readonly ICloudAppServices _cloudAppService;
        protected readonly IAddressAppServices _addressAppService;
        protected readonly IPictureAppServices _pictureAppService;
        public IdentityController(IUserAppServices userAppService, IBoothAppServices boothAppService, ISellerAppServices sellerAppService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IRoleAppServices roleAppServices, ICustomerAppServices customerAppService, ICloudAppServices cloudAppService, IAddressAppServices addressAppService, IPictureAppServices pictureAppService)
        {
            _userAppService = userAppService;
            _boothAppService = boothAppService;
            _sellerAppService = sellerAppService;
            _roleManager = roleManager;
            _userManager = userManager;
            _roleAppServices = roleAppServices;
            _customerAppService = customerAppService;
            _cloudAppService = cloudAppService;
            _addressAppService = addressAppService;
            _pictureAppService = pictureAppService;
        }



        [AllowAnonymous]
        [HttpGet]

        public IActionResult SellerRegister()
        {
            return View();
        }

        
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> SellerRegister(SellerRegisterViewModel sellerRegister, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _cloudAppService.AddPhoto(sellerRegister.Image, cancellation);

                var sellerUser = new AppUser
                {
                    PhoneNumber = sellerRegister.PhoneNumber,
                    Email = sellerRegister.Email,
                    FirstName = sellerRegister.FirstName,
                    LastName = sellerRegister.LastName,
                    UserName = sellerRegister.UserName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    RegisterTime = DateTime.Now,
                    DeleteTime = null,
                    IsDeleted = false,
                    Seller = new Domain.Core.Models.Entities.Seller
                    {
                        Address = new Address
                        {
                            Alley = sellerRegister.Address.Alley,
                            Street = sellerRegister.Address.Street,
                            City = sellerRegister.Address.City,
                            ExtraPart = sellerRegister.Address.ExtraPart,
                            PostCode = sellerRegister.Address.PostCode,
                        },
                        Picture = new Picture
                        {
                            Url = result.Url.ToString()
                        },
                        Booth = new Booth
                        {
                            Address = new Address
                            {
                                Alley = sellerRegister.BoothAddressDtOs.Alley,
                                Street = sellerRegister.BoothAddressDtOs.Street,
                                City = sellerRegister.BoothAddressDtOs.City,
                                ExtraPart = sellerRegister.BoothAddressDtOs.ExtraPart,
                                PostCode = sellerRegister.BoothAddressDtOs.PostCode,
                            },
                            BoothName = sellerRegister.Booth.BoothName
                        }

                    }
                         

                };
                //var registerUser =
                //    await _userAppService.Register(Seller, sellerRegister.Password, "Seller", cancellation);
                //if (registerUser.Succeeded)
                //{
                //    var Address = new AddressDtOs
                //    {
                //        Alley = sellerRegister.Address.Alley,
                //        Street = sellerRegister.Address.Street,
                //        City = sellerRegister.Address.City,
                //        ExtraPart = sellerRegister.Address.ExtraPart,
                //        PostCode = sellerRegister.Address.PostCode,
                //    };
                //    var registerAddress = await _addressAppService.AddAddress(Address, cancellation);

                //    var photo = new PictureDtOs
                //    {
                //        Url = result.Url.ToString(),

                //    };
                //    var registerPhoto = await _pictureAppService.AddPicture(photo, cancellation);

                //    var boothAddress = new AddressDtOs
                //    {
                //        Alley = sellerRegister.BoothAddressDtOs.Alley,
                //        Street = sellerRegister.BoothAddressDtOs.Street,
                //        City = sellerRegister.BoothAddressDtOs.City,
                //        ExtraPart = sellerRegister.BoothAddressDtOs.ExtraPart,
                //        PostCode = sellerRegister.BoothAddressDtOs.PostCode,
                //    };

                //    var registerBoothAddress = await _addressAppService.AddAddress(boothAddress, cancellation);
                //    var booth = new BoothDtOs
                //    {
                //        BoothName = sellerRegister.Booth.BoothName,
                //        BoothId = registerBoothAddress,
                //    };

                //    var registerBooth = await _boothAppService.AddBooth(booth, cancellation);

                //    var sellerTable = new SellerDtOs
                //    {
                //        BoothId = registerBooth,
                //        AddressId = registerAddress,
                //        AppUserId = Seller.Id,
                //        PictureId = registerPhoto,
                //        Wallet = 0

                //    };
                //    var registerSeller = await _sellerAppService.AddSeller(sellerTable, cancellation);
                //}
                var register = await _userAppService.Register(sellerUser, sellerRegister.Password, "Seller", cancellation);
                if (register.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
            
        }
        [AllowAnonymous]
        [HttpGet]

        public IActionResult CustomerRegister()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        
        public async Task<IActionResult> CustomerRegister(CustomerRegisterViewModel customerRegister, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _cloudAppService.AddPhoto(customerRegister.Image, cancellation);

                var customerUser = new AppUser
                {
                    PhoneNumber = customerRegister.PhoneNumber,
                    Email = customerRegister.Email,
                    FirstName = customerRegister.FirstName,
                    LastName = customerRegister.LastName,
                    UserName = customerRegister.UserName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    RegisterTime = DateTime.Now,
                    DeleteTime = null,
                    IsDeleted = false,
                    Customer = new Domain.Core.Models.Entities.Customer
                    {
                        Address = new List<Address>
                        {
                            new Address
                            {
                                Alley = customerRegister.Address.Alley,
                                Street = customerRegister.Address.Street,
                                City = customerRegister.Address.City,
                                ExtraPart = customerRegister.Address.ExtraPart,
                                PostCode = customerRegister.Address.PostCode,
                            }
                            
                        },
                        Picture = new Picture
                        {
                            Url = result.Url.ToString(),
                        },

                    }
                    
                };
                var registerUser =
                    await _userAppService.Register(customerUser, customerRegister.Password, "Customer", cancellation);
                
                if (registerUser.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
           
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel login, CancellationToken cancellation)
        {

            if (ModelState.IsValid)
            {
                var result = await _userAppService.SignIn(login.Email, login.Password, cancellation);
                if (result.Succeeded)
                {
                    var role = await _roleAppServices.GetUserRole(login.Email);
                    if (role.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });
                    }
                    else if (role.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "CustomerPanel", new { area = "Customer" });
                    }
                    else if (role.Contains("Seller"))
                    {
                        return RedirectToAction("Index", "SellerPanel", new { area = "Seller" });
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(login);
                }
            }
            return View(login);

        }
        public async Task<IActionResult> Logout()
        {
            await _userAppService.SignOut();

            
            return RedirectToAction("Index", "Home");
        }
        //if (registerUser.Succeeded)
        //{
        //    var Address = new AddressDtOs
        //    {
        //        Alley = customerRegister.Address.Alley,
        //        Street = customerRegister.Address.Street,
        //        City = customerRegister.Address.City,
        //        ExtraPart = customerRegister.Address.ExtraPart,
        //        PostCode = customerRegister.Address.PostCode,
        //    };
        //    var registerAddress = await _addressAppService.AddAddress(Address, cancellation);

        //    var photo = new PictureDtOs
        //    {
        //        Url = result.Url.ToString(),

        //    };
        //    var registerPhoto = await _pictureAppService.AddPicture(photo, cancellation);

        //    var customerTable = new CustomerDtOs
        //    {
        //        AppUserId = Customer.Id,
        //        PictureId = registerPhoto,
        //        Wallet = 0,
        //        AddressCustomers = new List<AddressCustomer>
        //        {
        //            new AddressCustomer
        //            {
        //                AddressId = registerAddress
        //            }
        //        }
        //    };

        //    var CustomerRegisterId = await _customerAppService.AddCustomer(customerTable, cancellation);

        //}
        //else
        //{
        //    return BadRequest();
        //}
    }
}
