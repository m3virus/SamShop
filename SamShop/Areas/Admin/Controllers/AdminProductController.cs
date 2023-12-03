using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using SamShop.Domain.Appservices;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Domain.Service;
using SamShop.endpoint.Areas.Admin.Models;
using SamShop.endpoint.Areas.Seller.Models;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminProductController : Controller
    {
        private readonly IProductAppServices _productAppServices;
        protected readonly ICategoryAppServices _categoryAppServices;
        protected readonly ICloudAppServices _cloudAppServices;
        protected readonly IPictureAppServices _pictureAppServices;

        public AdminProductController(IProductAppServices productAppServices, ICategoryAppServices categoryAppServices, ICloudAppServices cloudAppServices, IPictureAppServices pictureAppServices)
        {
            _productAppServices = productAppServices;
            _categoryAppServices = categoryAppServices;
            _cloudAppServices = cloudAppServices;
            _pictureAppServices = pictureAppServices;
        }

        public IActionResult Index()
        {
            return View(_productAppServices.GetAllProduct().Where(x =>x.IsDeleted!= true).OrderBy(x =>x.IsAccepted));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId, CancellationToken cancellation)
        {
            var productDefault = await _productAppServices.GetProductById(productId, cancellation);

            if (productDefault != null)
            {
                var allCategories = _categoryAppServices.GetAllCategory();
                var product = new AdminProductViewModel
                {
                    ProductId = productDefault.ProductId,
                    ProductName = productDefault.ProductName,
                    Amount = productDefault.Amount,
                    Price = productDefault.Price,

                    ProductPictures = productDefault.Pictures.Select(picture => new AdminPictureViewModel
                    {
                        PictureId = picture.PictureId,
                        Url = picture.Url,
                    }).ToList(),

                    AvailableCategories = allCategories.Select(category => new SelectListItem
                    {
                        Value = category.CategoryId.ToString(),
                        Text = category.CategoryName
                    }).ToList(),
                    SelectedCategoryId = productDefault.Category.CategoryId,

                    CurrentCategoryId = productDefault.Category.CategoryId,

                };
                return View(product);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]

        public async Task<IActionResult> Edit(AdminProductViewModel product, CancellationToken cancellation)
        {
            var productById = await _productAppServices.GetProductById(product.ProductId, cancellation);
            if (productById != null)
            {
                if (product.NewPictures != null && product.NewPictures.Any())
                {
                    foreach (var pictureFile in product.NewPictures)
                    {
                        var uploadResult = await _cloudAppServices.AddPhoto(pictureFile, cancellation);

                        var newPicture = new Picture
                        {
                            Url = uploadResult.Url.ToString(),
                        };

                        productById.Pictures.Add(newPicture);
                    }
                }

                productById.ProductName = product.ProductName;
                productById.Amount = product.Amount;
                productById.Price = product.Price;
                productById.Category = new Category
                {
                    CategoryId = product.SelectedCategoryId,
                };

                await _productAppServices.UpdateProduct(productById, cancellation);

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

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
        public async Task<IActionResult> PictureDeleter(int PictureId, int ProductId, CancellationToken cancellation)
        {
            await _pictureAppServices.DeletePicture(PictureId, cancellation);
            return RedirectToAction("Edit", "AdminProduct", new { Areas = "Admin", ProductId });
        }

    }
}
