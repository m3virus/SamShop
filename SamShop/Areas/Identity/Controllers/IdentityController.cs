using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;

using SamShop.endpoint.Areas.Identity.Models;
using System.Security.Claims;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;

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
        protected readonly IHttpContextAccessor _httpContext;
        public IdentityController(IUserAppServices userAppService, IBoothAppServices boothAppService, ISellerAppServices sellerAppService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IRoleAppServices roleAppServices, ICustomerAppServices customerAppService, ICloudAppServices cloudAppService, IAddressAppServices addressAppService, IPictureAppServices pictureAppService, IHttpContextAccessor httpContext)
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
            _httpContext = httpContext;
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
                    Seller = new Domain.Core.Models.Entities.Seller()
                    {
                        Address = new Address
                        {
                            Alley = sellerRegister.Address.Alley,
                            Street = sellerRegister.Address.Street,
                            State = sellerRegister.Address.State,
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
                                State = sellerRegister.BoothAddressDtOs.State,
                                City = sellerRegister.BoothAddressDtOs.City,
                                ExtraPart = sellerRegister.BoothAddressDtOs.ExtraPart,
                                PostCode = sellerRegister.BoothAddressDtOs.PostCode,
                            },
                            BoothName = sellerRegister.Booth.BoothName
                        }

                    }
                         

                };
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
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Customer = new Domain.Core.Models.Entities.Customer
                    {
                        Address = new List<Address>
                        {
                            new Address
                            {
                                Alley = customerRegister.Address.Alley,
                                Street = customerRegister.Address.Street,
                                State = customerRegister.Address.State,
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
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    var userRole = await _userManager.GetRolesAsync(user);
                    if (user.UserName != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                        };
                        if (userRole.Any())
                        {
                            claims.Add(new Claim(ClaimTypes.Role, userRole.First()));
                        }
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) // Set your desired expiration time
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity) , authProperties);
                    }

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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _userAppService.SignOut();


            return RedirectToAction("SignIn", "Identity");
        }
    }
}
