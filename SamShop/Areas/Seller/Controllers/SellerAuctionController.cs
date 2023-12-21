using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamShop.Domain.Appservices;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Seller.Models;
using System.Security.Claims;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class SellerAuctionController : Controller
    {
        protected readonly IAuctionAppServices _auctionAppServices;
        protected readonly ICloudAppServices _cloudAppServices;
        protected readonly ICategoryAppServices _categoryAppServices;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IProductAppServices _productAppServices;

        public SellerAuctionController(IAuctionAppServices auctionAppServices, ICloudAppServices cloudAppServices, ICategoryAppServices categoryAppServices, UserManager<AppUser> userManager, ISellerAppServices sellerAppServices, IProductAppServices productAppServices)
        {
            _auctionAppServices = auctionAppServices;
            _cloudAppServices = cloudAppServices;
            _categoryAppServices = categoryAppServices;
            _userManager = userManager;
            _sellerAppServices = sellerAppServices;
            _productAppServices = productAppServices;
        }

        public async Task<IActionResult> AuctionHistory()
        {
            var auctions = _auctionAppServices.GetAllAuction();
            if (auctions!=null)
            {
                var auctionView = auctions.Select(auction => new AuctionViewModel
                {
                    AuctionId = auction.AuctionId,
                    AuctionName = auction.AuctionTitle,
                    ProductName = auction.Product.ProductName,
                    LowestOffer = auction.TheLowestOffer,
                    BoothName = auction.Product.Booth.BoothName,
                    IsActive = auction.IsActive,
                    StartTime = auction.StartTime,
                    EndTime = auction.EndTime,
                    ProductPictures = auction.Product.Pictures.Select(picture => new SellerPictureViewModel
                    {
                        Url = picture.Url,
                    }).ToList(),
                    AuctionOffers = auction.AuctionOffers.Select(offer => new AuctionOfferViewModel
                    {
                        AuctionId = offer.AuctionId,
                        CustomerName = offer.Customer.AppUser.UserName,
                        CustomerId = offer.Customer.CustomerId,
                        OfferValue = offer.OfferValue,
                        OfferTime = offer.OfferTime,
                        IsAccept = offer.IsAccept,
                    }).ToList(),
                }).ToList();
                return View(auctionView);
            }
            else
            {
                return Content("you dont have auction yet");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddAuction(int boothId, CancellationToken cancellation)
        {
            var allCategories = _categoryAppServices.GetAllCategory();
            var auction = new AuctionAdderViewModel()
            {
                Title = "default",
                TheLowestPrice = 0,
                EndTime = DateTime.Now,
                StartTime = DateTime.Now,
                Product = new SellerBoothProductAdderViewModel
                {
                    BoothId = boothId,
                    ProductName = "ProductName",
                    Price = 0,
                    Amount = 1,
                    AvailableCategories = allCategories.Select(category => new SelectListItem
                    {
                        Value = category.CategoryId.ToString(),
                        Text = category.CategoryName
                    }).ToList(),
                }

                

            };
            return View(auction);
        }

        public async Task<IActionResult> AddAuction(AuctionAdderViewModel auction, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                int appUserId = Convert.ToInt32(userId);
                var seller = await _sellerAppServices.GetSellerByAppUserId(appUserId, cancellation);
                List<Picture> newPictures = new List<Picture>();

                if (auction.Product.NewPictures != null && auction.Product.NewPictures.Any())
                {
                    foreach (var pictureFile in auction.Product.NewPictures)
                    {
                        var uploadResult = await _cloudAppServices.AddPhoto(pictureFile, cancellation);

                        var newPicture = new Picture
                        {
                            Url = uploadResult.Url.ToString(),
                        };

                        newPictures.Add(newPicture);
                    }
                }

                var Product = new ProductDtOs
                {
                    BoothId = auction.Product.BoothId,
                    ProductName = auction.Product.ProductName,
                    Price = 0,
                    Amount = 1,
                    IsAccepted = false,
                    IsDeleted = false,
                    IsAvailable = false,
                    CategoryId = auction.Product.SelectedCategoryId,
                    Pictures = newPictures
                };
                var productAddId = await _productAppServices.AddProduct(Product, cancellation);
                var auctionAdding = new AuctionDtOs
                {
                    AuctionTitle = auction.Title,
                    TheLowestOffer = auction.TheLowestPrice,
                    SellerId = seller.SellerId,
                    ProductId = productAddId,
                    StartTime = auction.StartTime,
                    EndTime = auction.EndTime,
                };
                await _auctionAppServices.AddAuction(auctionAdding, cancellation);
                return RedirectToAction("Index", "SellerPanel");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
