using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Admin.Models;
using SamShop.endpoint.Areas.Customer.Models;
using SamShop.Domain.Appservices;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IAdminAppServices _adminAppServices;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICloudAppServices _cloudAppServices;


        public AdminPanelController(IAdminAppServices adminAppServices, UserManager<AppUser> userManager, ICloudAppServices cloudAppServices)
        {
            _adminAppServices = adminAppServices;
            _userManager = userManager;
            _cloudAppServices = cloudAppServices;
        }

        public async Task<IActionResult> Index(CancellationToken cancellation)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var admin = await _adminAppServices.GetAdminByAppUserId(appUserId, cancellation);

            var viewModel = new AdminDashboardViewModel
            {
                ProfilePicture = new AdminPictureViewModel
                {
                    Url = admin.Picture?.Url
                },

                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                
                PrimaryAddresses = new AdminAddressViewModel
                {
                    Alley = admin.Address.Alley,
                    state = admin.Address.State,
                    City = admin.Address.City,
                    Street = admin.Address.Street,
                    ExtraPart = admin.Address.ExtraPart,
                    PostCode = admin.Address.PostCode,
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
            var admin = await _adminAppServices.GetAdminByAppUserId(appUserId, cancellation);

            var defaultValue = new AdminProfileEditViewModel();
            if (user != null && admin != null)
            {
                defaultValue.UserName = user.UserName;
                defaultValue.FirstName = user.FirstName;
                defaultValue.LastName = user.LastName;

                defaultValue.Address = new AdminAddressViewModel
                {
                    Alley = admin.Address.Alley,
                    state = admin.Address.State,
                    City = admin.Address.City,
                    Street = admin.Address.Street,
                    ExtraPart = admin.Address.ExtraPart,
                    PostCode = admin.Address.PostCode,
                };
            }
            return View(defaultValue);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdminProfileEditViewModel adminProfileEdit, CancellationToken cancellation)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            int appUserId = Convert.ToInt32(userId);
            var admin = await _adminAppServices.GetAdminByAppUserId(appUserId, cancellation);



            if (user != null && admin != null)
            {
                if (adminProfileEdit.Picture != null)
                {
                    await _cloudAppServices.DeletePhoto(admin.Picture.PictureId, cancellation);
                }

                user.UserName = adminProfileEdit.UserName;
                user.FirstName = adminProfileEdit.FirstName;
                user.LastName = adminProfileEdit.LastName;

                admin.Address = new Address
                {
                    Alley = adminProfileEdit.Address.Alley,
                    State = adminProfileEdit.Address.state,
                    City = adminProfileEdit.Address.City,
                    Street = adminProfileEdit.Address.Street,
                    ExtraPart = adminProfileEdit.Address.ExtraPart,
                    PostCode = adminProfileEdit.Address.PostCode,
                };
                if (adminProfileEdit.Picture != null)
                {
                    var pictureUrl = await _cloudAppServices.AddPhoto(adminProfileEdit.Picture, cancellation);

                    admin.Picture = new Picture
                    {
                        Url = pictureUrl.Url.ToString(),
                    };
                }
            }

            await _adminAppServices.UpdateAdmin(admin, cancellation);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}
