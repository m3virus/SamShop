using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamShop.endpoint.Areas.Admin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Seller.Models;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class SellerBoothController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly ICloudAppServices _cloudAppServices;
        protected readonly IBoothAppServices _boothAppServices;
        public SellerBoothController(UserManager<AppUser> userManager, ISellerAppServices sellerAppServices, ICloudAppServices cloudAppServices, IBoothAppServices boothAppServices)
        {
            _userManager = userManager;
            _sellerAppServices = sellerAppServices;
            _cloudAppServices = cloudAppServices;
            _boothAppServices = boothAppServices;
        }

        public async Task<IActionResult> BoothDetails(int BoothId, CancellationToken cancellation)
        {
            var BoothById = await _boothAppServices.GetBoothById(BoothId, cancellation);
            if (BoothById != null)
            {
                var boothView = new SellerBoothViewModel
                {
                    BoothId = BoothById.BoothId,
                    BoothName = BoothById.BoothName,
                    BoothAddress = new SellerAddressViewModel
                    {
                        Alley = BoothById.Address.Alley,
                        Street = BoothById.Address.Street,
                        City = BoothById.Address.City,
                        state = BoothById.Address.State,
                        ExtraPart = BoothById.Address.ExtraPart,
                        PostCode = BoothById.Address.PostCode,
                    },
                    BoothProducts = BoothById.Products.Select(boothProduct => new SellerBoothProductViewModel
                    {
                        ProductId = boothProduct.ProductId,
                        ProductName = boothProduct.ProductName,
                        Price = boothProduct.Price,
                        Amount = boothProduct.Amount,
                        ProductCategory = new SellerBoothProductCategoryViewModel
                        {
                            category = boothProduct.Category.CategoryName
                        },
                        ProductPictures = boothProduct.Pictures.Select(productPicture => new SellerPictureViewModel
                        {
                            Url = productPicture.Url,
                        }).ToList(),
                        
                    }).ToList(),
                };
                return View(boothView);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> BoothEdit(int BoothId, CancellationToken cancellation)
        {
            var BoothById = await _boothAppServices.GetBoothById(BoothId, cancellation);
            if (BoothById != null)
            {
                var boothDefault = new SellerBoothViewModel
                {
                    BoothId = BoothById.BoothId,
                    BoothName = BoothById.BoothName,
                    BoothAddress = new SellerAddressViewModel
                    {
                        Alley = BoothById.Address.Alley,
                        Street = BoothById.Address.Street,
                        City = BoothById.Address.City,
                        state = BoothById.Address.State,
                        ExtraPart = BoothById.Address.ExtraPart,
                        PostCode = BoothById.Address.PostCode,
                    }
                };
                return View(boothDefault);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> BoothEdit(SellerBoothViewModel editedBoothViewModel, CancellationToken cancellation)
        {
            var BoothById = await _boothAppServices.GetBoothById(editedBoothViewModel.BoothId, cancellation);
            if (BoothById != null)
            {
                BoothById.BoothName = editedBoothViewModel.BoothName;
                BoothById.Address = new Address
                {
                    Alley = editedBoothViewModel.BoothAddress.Alley,
                    Street = editedBoothViewModel.BoothAddress.Street,
                    City = editedBoothViewModel.BoothAddress.City,
                    State = editedBoothViewModel.BoothAddress.state,
                    ExtraPart = editedBoothViewModel.BoothAddress.ExtraPart,
                    PostCode = editedBoothViewModel.BoothAddress.PostCode,
                };
                await _boothAppServices.UpdateBooth(BoothById, cancellation);
                return RedirectToAction("BoothDetails", new {editedBoothViewModel.BoothId});
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
