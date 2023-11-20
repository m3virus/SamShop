using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly IProductServices _productServices;

        public AdminProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            return View(_productServices.GetProductsByIsAccepted());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId , CancellationToken cancellation)
        {
            var result = await _productServices.GetProductById(productId , cancellation);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Product product, CancellationToken cancellation)
        {
            await _productServices.UpdateProduct(product, cancellation);
            return View(product);

        }
        public async Task<IActionResult> Confirm(int productId, CancellationToken cancellation)
        {
            await _productServices.ConfirmProduct(productId, cancellation);
            return RedirectToAction("Index");
            //return View();
        }


        public async Task<IActionResult> Delete(int productId, CancellationToken cancellation)
        {
            await _productServices.DeleteProduct(productId, cancellation);
            return RedirectToAction("Index");
        }

    }
}
