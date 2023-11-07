using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Services;
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
