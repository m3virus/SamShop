using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Admin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SamShop.endpoint.Areas.Seller.Models;
using SamShop.Domain.Appservices;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class SellerPanelController : Controller
    {
        
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly ICloudAppServices _cloudAppServices;

        public SellerPanelController(UserManager<AppUser> userManager, ISellerAppServices sellerAppServices, ICloudAppServices cloudAppServices)
        {
            _userManager = userManager;
            _sellerAppServices = sellerAppServices;
            _cloudAppServices = cloudAppServices;
        }

        public async Task<IActionResult> Index(CancellationToken cancellation)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var seller = await _sellerAppServices.GetSellerByAppUserId(appUserId, cancellation);

            var viewModel = new SellerDashboardViewModel
            {
                
                ProfilePicture = new SellerPictureViewModel()
                {
                    Url = seller.Picture?.Url
                },

                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,

                WalletAmount = seller.Wallet,
                PrimaryAddresses = new SellerAddressViewModel
                {
                    Alley = seller.Address.Alley,
                    state = seller.Address.State,
                    City = seller.Address.City,
                    Street = seller.Address.Street,
                    ExtraPart = seller.Address.ExtraPart,
                    PostCode = seller.Address.PostCode,
                },
                Booth = new SellerBoothViewModel
                {
                    BoothId = seller.Booth.BoothId,
                    BoothName = seller.Booth.BoothName,
                    BoothAddress = new SellerAddressViewModel
                    {
                        Alley = seller.Booth.Address.Alley,
                        Street = seller.Booth.Address.Street,
                        City = seller.Booth.Address.City,
                        state = seller.Booth.Address.State,
                        ExtraPart = seller.Booth.Address.ExtraPart,
                        PostCode = seller.Booth.Address.PostCode,
                    }
                }
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var seller = await _sellerAppServices.GetSellerByAppUserId(appUserId, cancellation);

            var defaultValue = new SellerProfileEditViewModel();
            if (user != null && seller != null)
            {
                defaultValue.UserName = user.UserName;
                defaultValue.FirstName = user.FirstName;
                defaultValue.LastName = user.LastName;

                defaultValue.Address = new SellerAddressViewModel
                {
                    Alley = seller.Address.Alley,
                    state = seller.Address.State,
                    City = seller.Address.City,
                    Street = seller.Address.Street,
                    ExtraPart = seller.Address.ExtraPart,
                    PostCode = seller.Address.PostCode,
                };
            }
            return View(defaultValue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SellerProfileEditViewModel sellerProfileEdit, CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            int appUserId = Convert.ToInt32(userId);
            var seller = await _sellerAppServices.GetSellerByAppUserId(appUserId, cancellation);



            if (user != null && seller != null)
            {
                if (sellerProfileEdit.Picture != null)
                {
                    await _cloudAppServices.DeletePhoto(seller.Picture.PictureId, cancellation);
                }

                user.UserName = sellerProfileEdit.UserName;
                user.FirstName = sellerProfileEdit.FirstName;
                user.LastName = sellerProfileEdit.LastName;

                seller.Address = new Address
                {
                    Alley = sellerProfileEdit.Address.Alley,
                    State = sellerProfileEdit.Address.state,
                    City = sellerProfileEdit.Address.City,
                    Street = sellerProfileEdit.Address.Street,
                    ExtraPart = sellerProfileEdit.Address.ExtraPart,
                    PostCode = sellerProfileEdit.Address.PostCode,
                };
                if (sellerProfileEdit.Picture != null)
                {
                    var pictureUrl = await _cloudAppServices.AddPhoto(sellerProfileEdit.Picture, cancellation);

                    seller.Picture = new Picture
                    {
                        Url = pictureUrl.Url.ToString(),
                    };
                }
            }

            await _sellerAppServices.UpdateSeller(seller, cancellation);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}
