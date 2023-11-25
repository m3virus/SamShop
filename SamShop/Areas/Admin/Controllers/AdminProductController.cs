using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminProductController : Controller
    {
        private readonly IProductAppServices _productAppServices;

        public AdminProductController(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        public IActionResult Index()
        {
            return View(_productAppServices.GetAllProduct().Where(x =>x.IsDeleted!= true).OrderBy(x =>x.IsAccepted));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId, CancellationToken cancellation)
        {
            var result = await _productAppServices.GetProductById(productId, cancellation);
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

        public async Task<IActionResult> Edit(ProductDtOs product, CancellationToken cancellation)
        {
            await _productAppServices.UpdateProduct(product, cancellation);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Confirm(int productId, CancellationToken cancellation)
        {
            await _productAppServices.ConfirmProduct(productId, cancellation);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int productId, CancellationToken cancellation)
        {
            await _productAppServices.DeleteProduct(productId, cancellation);
            return RedirectToAction("Index");
        }

    }
}
