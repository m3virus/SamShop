using Microsoft.AspNetCore.Mvc;
using SamShop.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Models;
using System.Security.Claims;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;

namespace SamShop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBoothAppServices _boothAppServices;
        private readonly IProductAppServices _productAppServices;
        private readonly ICommentAppServices _commentAppServices;
        private readonly ICategoryAppServices _categoryAppServices;
        private readonly IAuctionAppServices _auctionAppServices;
        private readonly IAuctionOfferAppServices _auctionOfferAppServices;
        private readonly ICustomerAppServices _customerAppServices;

        public HomeController(ILogger<HomeController> logger, IBoothAppServices boothAppServices, IProductAppServices productAppServices, ICommentAppServices commentAppServices, ICategoryAppServices categoryAppServices, IAuctionAppServices auctionAppServices, IAuctionOfferAppServices auctionOfferAppServices, ICustomerAppServices customerAppServices)
        {
            _logger = logger;
            _boothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _commentAppServices = commentAppServices;
            _categoryAppServices = categoryAppServices;
            _auctionAppServices = auctionAppServices;
            _auctionOfferAppServices = auctionOfferAppServices;
            _customerAppServices = customerAppServices;
        }

        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            var categories = _categoryAppServices.GetAllCategory().Where(x => x.IsDeleted != true);
            var booths = _boothAppServices.GetAllBooth().Where(x => x.IsDeleted != true);

            var viewModel = new ShopHomeViewModel
            {
                Categories = categories.Select(category => new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Products = category.Products.Where(x => x.IsDeleted != true && x.IsAccepted == true && x.IsAvailable == true).Select(product => new ProductViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Amount = product.Amount,
                        Price = product.Price,
                        Booth = new BoothViewModel
                        {
                            BoothName = product.Booth.BoothName,
                        }

                    }).ToList()
                }).ToList(),

                Booths = booths.Select(booth => new BoothViewModel
                {
                    BoothId = booth.BoothId,
                    BoothName = booth.BoothName,
                    Products = booth.Products.Where(x => x.IsDeleted != true && x.IsAccepted == true && x.IsAvailable == true).Select(product => new ProductViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Amount = product.Amount,
                        Price = product.Price,
                        Category = new CategoryViewModel
                        {
                            CategoryId = product.Category.CategoryId,
                            CategoryName = product.Category.CategoryName,
                        }
                    }).ToList()
                }).ToList()
            };

            return View(viewModel);
        }


        public async Task<IActionResult> BoothDetails(int id, CancellationToken cancellation)
        {
            var mainBooth = await _boothAppServices.GetBoothById(id, cancellation);
            var boothView = new BoothViewModel
            {
                BoothId = id,
                BoothName = mainBooth.BoothName,
                Products = mainBooth.Products.Where(product => product.IsAccepted == true && product.IsDeleted != true && product.IsAvailable == true).Select(product => new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Amount = product.Amount,
                    pictures = product.Pictures.Where(picture => picture.IsDeleted != true).Select(picture => new HomePictureViewModel
                    {
                        Url = picture.Url,
                    }).ToList(),
                    Comments = product.Comments.Select(comment => new HomeCommentViewModel
                    {
                        CommentId = comment.CommentId,
                        Message = comment.Message,
                        CreatedDate = comment.CommentDate,
                        IsDeleted = comment.IsDeleted,
                        IsAccepted = comment.IsAccepted,
                        Customer = new HomeCustomerViewModel
                        {
                            CustomerId = comment.Customer.CustomerId,
                            User = new HomeAppUserViewModel
                            {
                                UserName = comment.Customer.AppUser.UserName
                            }
                        }

                    }).ToList(),
                    Category = new CategoryViewModel
                    {
                        CategoryName = product.Category.CategoryName,
                        CategoryId = product.CategoryId,
                    }
                }).ToList(),
            };
            return View(boothView);
        }

        public async Task<IActionResult> CategoryDetails(int id, CancellationToken cancellation)
        {
            var mainCategory = await _categoryAppServices.GetCategoryById(id, cancellation);
            var categoryView = new CategoryViewModel
            {
                CategoryId = mainCategory.CategoryId,
                CategoryName = mainCategory.CategoryName,
                Products = mainCategory.Products.Where(product => product.IsAccepted == true && product.IsAvailable == true && product.IsDeleted != true).Select(product => new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Amount = product.Amount,
                    pictures = product.Pictures.Where(picture => picture.IsDeleted != true).Select(picture => new HomePictureViewModel
                    {
                        Url = picture.Url,
                    }).ToList(),
                    Comments = product.Comments.Select(comment => new HomeCommentViewModel
                    {
                        CommentId = comment.CommentId,
                        Message = comment.Message,
                        CreatedDate = comment.CommentDate,
                        IsDeleted = comment.IsDeleted,
                        IsAccepted = comment.IsAccepted,
                        Customer = new HomeCustomerViewModel
                        {
                            CustomerId = comment.Customer.CustomerId,
                            User = new HomeAppUserViewModel
                            {
                                UserName = comment.Customer.AppUser.UserName
                            }
                        }

                    }).ToList(),
                    Booth = new BoothViewModel
                    {
                        BoothId = product.Booth.BoothId,
                        BoothName = product.Booth.BoothName,
                    }
                }).ToList(),
            };
            return View(categoryView);
        }

        public async Task<IActionResult> ActiveAuctions(CancellationToken cancellation)
        {
            var activeAuctions = _auctionAppServices.GetAllAuction()
                .Where(auction => auction.IsActive == true && auction.IsAccepted == true).ToList();
            return View(activeAuctions);
        }

        [HttpGet]
        public async Task<IActionResult> AuctionOffers(int AuctionId, CancellationToken cancellation)
        {
            var auctionOfferForm = new HomeAuctionOfferViewModel
            {
                AuctionId = AuctionId,
                CustomerId = Convert.ToInt16(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                Offer = 0
            };
            return View(auctionOfferForm);
        }
        [HttpPost]
        public async Task<IActionResult> AuctionOffers(HomeAuctionOfferViewModel offerView, CancellationToken cancellation)
        {
            var customer = await _customerAppServices.GetCustomerByAppUserId(offerView.CustomerId, cancellation);
            var auction = await _auctionAppServices.GetAuctionById(offerView.AuctionId, cancellation);

            if (customer != null && auction != null)
            {
                if (customer.Wallet < offerView.Offer)
                {
                    return Content("You must charge your wallet");
                }
                else
                {
                    var submitedOffer = new AuctionOfferDtOs
                    {
                        OfferValue = offerView.Offer,
                        AuctionId = offerView.AuctionId,
                        CustomerId = customer.CustomerId,
                    };
                    await _auctionOfferAppServices.AddAuctionOffer(submitedOffer, cancellation);
                }
            }

            return RedirectToAction("Index");
        }

    }
}