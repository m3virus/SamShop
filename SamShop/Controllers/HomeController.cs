using Microsoft.AspNetCore.Mvc;
using SamShop.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
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

        public HomeController(ILogger<HomeController> logger, IBoothAppServices boothAppServices, IProductAppServices productAppServices, ICommentAppServices commentAppServices)
        {
            _logger = logger;
            _boothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _commentAppServices = commentAppServices;
        }

        public IActionResult Index()
        {
            
            return View(_boothAppServices.GetAllBooth());
        }


        public async Task<IActionResult> Details(int id , CancellationToken cancellation)
        {
            var mainBooth = await _boothAppServices.GetBoothById(id, cancellation);

            return View(mainBooth);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}