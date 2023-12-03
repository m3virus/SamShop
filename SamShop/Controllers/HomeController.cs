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

        public HomeController(ILogger<HomeController> logger, IBoothAppServices boothAppServices, IProductAppServices productAppServices, ICommentAppServices commentAppServices, ICategoryAppServices categoryAppServices)
        {
            _logger = logger;
            _boothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _commentAppServices = commentAppServices;
            _categoryAppServices = categoryAppServices;
        }

        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            var categories = _categoryAppServices.GetAllCategory().Where(x => x.IsDeleted != true);
            var booths = _boothAppServices.GetAllBooth().Where(x =>x.IsDeleted != true);

            var viewModel = new ShopHomeViewModel
            {
                Categories = categories.Select(category => new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Products = category.Products.Where(x => x.IsDeleted != true && x.IsAccepted == true).Select(product => new ProductViewModel
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
                    Products = booth.Products.Where(x =>x.IsDeleted != true && x.IsAccepted == true).Select(product => new ProductViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Amount = product.Amount,
                        Price = product.Price,
                        Category = new CategoryViewModel
                        {
                            CategoryName = product.Category.CategoryName,
                        }
                    }).ToList()
                }).ToList()
            };

            return View(viewModel);
        }


        public async Task<IActionResult> BoothDetails(int id , CancellationToken cancellation)
        {
            var mainBooth = await _boothAppServices.GetBoothById(id, cancellation);
            var boothView = new BoothViewModel
            {
                BoothId = id,
                BoothName = mainBooth.BoothName,
                Products = mainBooth.Products.Where(product => product.IsAccepted == true && product.IsDeleted != true).Select(product => new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Amount = product.Amount,
                    pictures = product.Pictures.Select(picture => new HomePictureViewModel
                    {
                        Url = picture.Url,
                    }).ToList()
                }).ToList(),
            };
            return View(boothView);
        }

    }
}