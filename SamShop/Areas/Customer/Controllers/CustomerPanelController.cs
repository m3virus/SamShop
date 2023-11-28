using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamShop.endpoint.Areas.Customer.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize (Roles = "Customer")]
    public class CustomerPanelController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ICustomerAppServices _customerAppServices;
        protected readonly ICloudAppServices _cloudAppServices;

        public CustomerPanelController(UserManager<AppUser> userManager, ICustomerAppServices customerAppServices, ICloudAppServices cloudAppServices)
        {
            _userManager = userManager;
            _customerAppServices = customerAppServices;
            _cloudAppServices = cloudAppServices;
        }

        
        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);

            var viewModel = new CustomerDashbordViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                WalletAmount = customer.Wallet,
                PrimaryAddresses = customer.Addresses.Select(Address => new AddressViewModel
                {
                    Alley = Address.Alley,
                    Street = Address.Street,
                    City = Address.City,
                    state = Address.State,
                    ExtraPart = Address.ExtraPart,
                    PostCode = Address.PostCode,
                }).ToList(),
                ProfilePicture = new PictureViewModel
                {
                    Url = customer.Picture?.Url
                },
                Carts = customer.Carts.Select(cart => new CartViewModel
                {
                    CartId = cart.CartId,
                    Price = cart.TotalPrice,
                    Products = cart.Products.Select(product => new ProductViewModel
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Amount = product.Amount
                    }).ToList()
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> EditProfile(CustomerProfileEditViewModel profileEditView, CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);
            
            

            if (user != null && customer != null)
            {
                if (customer.PictureId != null)
                {
                    await _cloudAppServices.DeletePhoto(customer.Picture.PictureId, cancellation);
                }

                user.UserName = profileEditView.UserName;
                user.FirstName = profileEditView.FirstName;
                user.LastName = profileEditView.LastName;

                customer.Wallet = profileEditView.Wallet;

                customer.Addresses = new List<Address>
                {
                    new Address
                    {
                        Alley = profileEditView.Address.Alley,
                        Street = profileEditView.Address.Street,
                        City = profileEditView.Address.City,
                        State = profileEditView.Address.State,
                        ExtraPart = profileEditView.Address.ExtraPart,
                        PostCode = profileEditView.Address.PostCode
                    }

                };
                if(profileEditView.picture != null) {
                    var pictureUrl = await _cloudAppServices.AddPhoto(profileEditView.picture, cancellation);

                    customer.Picture = new Picture
                    {
                        Url = pictureUrl.Url.ToString(),
                    };
                }
            }

            await _customerAppServices.UpdateCustomer(customer, cancellation);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}
