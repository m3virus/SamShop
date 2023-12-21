using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using SamShop.Domain.Appservices;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.ProductDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.endpoint.Areas.Seller.Models;
using System.Linq;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class SellerBoothProductController : Controller
    {
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IPictureAppServices _pictureAppServices;
        protected readonly ICloudAppServices _cloudAppServices;
        protected readonly IBoothAppServices _boothAppServices;
        protected readonly IProductAppServices _productAppServices;
        protected readonly ICategoryAppServices _categoryAppServices;

        public SellerBoothProductController(ISellerAppServices sellerAppServices, ICloudAppServices cloudAppServices, IBoothAppServices boothAppServices, IProductAppServices productAppServices, ICategoryAppServices categoryAppServices, IPictureAppServices pictureAppServices)
        {
            _sellerAppServices = sellerAppServices;
            _cloudAppServices = cloudAppServices;
            _boothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _categoryAppServices = categoryAppServices;
            _pictureAppServices = pictureAppServices;
        }

        public async Task<IActionResult> ProductView(int ProductId, CancellationToken cancellation)
        {
            var Product = await _productAppServices.GetProductById(ProductId, cancellation);

            if (Product != null)
            {
                var ProductView = new SellerBoothProductViewModel
                {
                    ProductId = Product.ProductId,
                    ProductName = Product.ProductName,
                    ProductCategory = new SellerBoothProductCategoryViewModel
                    {
                        category = Product.Category.CategoryName,
                    },
                    Amount = Product.Amount,
                    Price = Product.Price,
                    ProductPictures = Product.Pictures.Select(ProductPicture => new SellerPictureViewModel
                    {
                        Url = ProductPicture.Url
                    }).ToList(),
                };
                return View(ProductView);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        public async Task<IActionResult> ProductEditor(int ProductId, CancellationToken cancellation)
        {
            var productDefault = await _productAppServices.GetProductById(ProductId, cancellation);

            if (productDefault != null)
            {
                var allCategories = _categoryAppServices.GetAllCategory();
                var product = new SellerBoothProductEditViewModel
                {
                    ProductId = productDefault.ProductId,
                    ProductName = productDefault.ProductName,
                    Amount = productDefault.Amount,
                    Price = productDefault.Price,

                    ProductPictures = productDefault.Pictures.Select(picture => new SellerPictureViewModel
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
        public async Task<IActionResult> ProductEditor(SellerBoothProductEditViewModel productEditView, CancellationToken cancellation)
        {
            var productById = await _productAppServices.GetProductById(productEditView.ProductId, cancellation);
            if (productById != null)
            {
                if (productEditView.NewPictures != null && productEditView.NewPictures.Any())
                {
                    foreach (var pictureFile in productEditView.NewPictures)
                    {
                        var uploadResult = await _cloudAppServices.AddPhoto(pictureFile, cancellation);

                        var newPicture = new Picture
                        {
                            Url = uploadResult.Url.ToString(),
                        };

                        productById.Pictures.Add(newPicture);
                    }
                }
                productById.ProductName = productEditView.ProductName;
                productById.Amount = productEditView.Amount;
                productById.Price = productEditView.Price;
                productById.Category = new Category
                {
                    CategoryId = productEditView.SelectedCategoryId,
                };
                if (productById.Amount == 0)
                {
                    productById.IsAvailable = false;
                }
                else
                if (productById.Amount >= 0)
                {
                    productById.IsAvailable = true;
                }
                else
                if (productById.Amount <= 0)
                {
                    return Content("you cant do that pls enter the correct value");
                }

                await _productAppServices.UpdateProduct(productById, cancellation);

                return RedirectToAction("ProductView", new { ProductId = productById.ProductId });
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddingProduct(int boothId, CancellationToken cancellation)
        {
            var allCategories = _categoryAppServices.GetAllCategory();
            var product = new SellerBoothProductAdderViewModel()
            {
                BoothId = boothId,
                ProductName = "",
                Amount = 0,
                Price = 0,

                AvailableCategories = allCategories.Select(category => new SelectListItem
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName
                }).ToList(),

            };
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddingProduct(SellerBoothProductAdderViewModel addingProduct, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {

                List<Picture> newPictures = new List<Picture>();

                if (addingProduct.NewPictures != null && addingProduct.NewPictures.Any())
                {
                    foreach (var pictureFile in addingProduct.NewPictures)
                    {
                        var uploadResult = await _cloudAppServices.AddPhoto(pictureFile, cancellation);

                        var newPicture = new Picture
                        {
                            Url = uploadResult.Url.ToString(),
                        };

                        newPictures.Add(newPicture);
                    }
                }

                var product = new ProductDtOs
                {
                    BoothId = addingProduct.BoothId,
                    ProductName = addingProduct.ProductName,
                    Amount = addingProduct.Amount,
                    Price = addingProduct.Price,
                    CategoryId = addingProduct.SelectedCategoryId,
                    Pictures = newPictures,
                };
                await _productAppServices.AddProduct(product, cancellation);
                return RedirectToAction("BoothDetails", "SellerBooth", new { BoothId = product.BoothId });
            }
            else
            {
                return NotFound();
            }


        }

        public async Task<IActionResult> PictureDeleter(int PictureId, int ProductId, CancellationToken cancellation)
        {
            await _pictureAppServices.DeletePicture(PictureId, cancellation);
            return RedirectToAction("ProductEditor", "SellerBoothProduct", new { Areas = "Seller", ProductId });
        }

    }
}
