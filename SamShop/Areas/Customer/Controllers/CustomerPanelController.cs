using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamShop.endpoint.Areas.Customer.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CustomerPanelController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ICustomerAppServices _customerAppServices;
        protected readonly ICloudAppServices _cloudAppServices;
        protected readonly ICommentAppServices _commentAppServices;
        protected readonly ICartAppServices _cartAppServices;
        protected readonly IProductAppServices _productAppServices;
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IWageAppServices _wageAppServices;

        public CustomerPanelController(UserManager<AppUser> userManager, ICustomerAppServices customerAppServices, ICloudAppServices cloudAppServices, ICommentAppServices commentAppServices, ICartAppServices cartAppServices, IProductAppServices productAppServices, IWageAppServices wageAppServices, ISellerAppServices sellerAppServices)
        {
            _userManager = userManager;
            _customerAppServices = customerAppServices;
            _cloudAppServices = cloudAppServices;
            _commentAppServices = commentAppServices;
            _cartAppServices = cartAppServices;
            _productAppServices = productAppServices;
            _wageAppServices = wageAppServices;
            _sellerAppServices = sellerAppServices;
        }


        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);

            var viewModel = new CustomerDashbordViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                WalletAmount = customer.Wallet,
                PrimaryAddresses = customer.Addresses.Select(Address => new AddressViewModel
                {
                    Alley = Address.Alley,
                    Street = Address.Street,
                    City = Address.City,
                    state = Address.State,
                    ExtraPart = Address.ExtraPart,
                    PostCode = Address.PostCode,
                }).ToList(),
                ProfilePicture = new PictureViewModel
                {
                    Url = customer.Picture?.Url
                },
                Carts = customer.Carts.Select(cart => new CartViewModel
                {
                    CartId = cart.CartId,
                    Price = cart.TotalPrice,
                    Products = cart.Products.Select(product => new ProductViewModel
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Amount = product.Amount
                    }).ToList()
                }).ToList()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ViewCart(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);
            var viewModel = new CustomerDashbordViewModel
            {
                Carts = customer.Carts.Select(cart => new CartViewModel
                {
                    CartId = cart.CartId,
                    Price = cart.TotalPrice,
                    IsPayed = cart.IsPayed,
                    Products = cart.Products.Select(product => new ProductViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Amount = product.Amount
                    }).ToList()
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;

            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);

            var defaultValue = new CustomerProfileEditViewModel();
            if (user != null && customer != null)
            {
                defaultValue.UserName = user.UserName;
                defaultValue.FirstName = user.FirstName;
                defaultValue.LastName = user.LastName;

                defaultValue.Wallet = customer.Wallet;
            }
            return View(defaultValue);
        }

        [HttpPost]

        public async Task<IActionResult> EditProfile(CustomerProfileEditViewModel profileEditView, CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);



            if (user != null && customer != null)
            {
                if (profileEditView.picture != null)
                {
                    await _cloudAppServices.DeletePhoto(customer.Picture.PictureId, cancellation);
                }

                user.UserName = profileEditView.UserName;
                user.FirstName = profileEditView.FirstName;
                user.LastName = profileEditView.LastName;

                customer.Wallet = profileEditView.Wallet;

                if (profileEditView.picture != null)
                {
                    var pictureUrl = await _cloudAppServices.AddPhoto(profileEditView.picture, cancellation);

                    customer.Picture = new Picture
                    {
                        Url = pictureUrl.Url.ToString(),
                    };
                }
            }

            await _customerAppServices.UpdateCustomer(customer, cancellation);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> LeaveComment(int ProductId, CancellationToken cancellation)
        {
            var defaultProduct = new CustomerCartProductCommentViewModel
            {
                ProductId = ProductId,
                Message = "please leave us your Comments"
            };
            return View(defaultProduct);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveComment(CustomerCartProductCommentViewModel commentViewModel, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int appUserId = Convert.ToInt32(userId);
                var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);

                var comment = new CommentDtOs
                {
                    ProductId = commentViewModel.ProductId,
                    Message = commentViewModel.Message,
                    CustomerId = customer.CustomerId,
                };
                await _commentAppServices.AddComment(comment, cancellation);
                return RedirectToAction("ViewCart");
            }
            else
            {
                return BadRequest();
            }


        }
        public async Task<IActionResult> CurrentCart(CancellationToken cancellation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);

            var cart = await _cartAppServices.GetCartByIsPayed(customer.CustomerId, cancellation);
            var cartView = new CartViewModel
            {
                CartId = cart.CartId,
                Price = cart.TotalPrice,
                IsPayed = cart.IsPayed,
                Products = cart.Products.Select(products => new ProductViewModel
                {
                    ProductId = products.ProductId,
                    Price = products.Price,
                    ProductName = products.ProductName,
                    ProductCategory = new CustomerCategoryViewModel
                    {
                        CategoryName = products.Category.CategoryName,
                        CategoryId = products.Category.CategoryId,
                    },
                    ProductBooth = new CustomerBoothViewModel
                    {
                        BoothId = products.Booth.BoothId,
                        BoothName = products.Booth.BoothName,
                    },
                    ProductPictures = products.Pictures.Where(picture => picture.IsDeleted == false).Select(picture => new PictureViewModel
                    {
                        Url = picture.Url
                    }).ToList(),
                }).ToList(),
            };
            return View(cartView);

        }

        public async Task<IActionResult> AddProduct(int ProductId, CancellationToken cancellation)
        {
            var product = await _productAppServices.GetProductById(ProductId, cancellation);
            if (product != null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int appUserId = Convert.ToInt32(userId);
                var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);
                var cart = await _cartAppServices.GetCartByIsPayed(customer.CustomerId, cancellation);
                cart.Products.Add(new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                });
                cart.TotalPrice += product.Price;
                await _cartAppServices.UpdateCart(cart, cancellation);
                return RedirectToAction("CurrentCart", "CustomerPanel");
            }
            else
            {
                return BadRequest();
            }

        }

        public async Task<IActionResult> Pay(int CartId, CancellationToken cancellation)
        {
            var cart = await _cartAppServices.GetCartById(CartId, cancellation);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int appUserId = Convert.ToInt32(userId);
            var customer = await _customerAppServices.GetCustomerByAppUserId(appUserId, cancellation);
            if (cart != null)
            {
                cart.IsPayed = true;
                await _cartAppServices.UpdateCart(cart, cancellation);

                if (customer.Wallet > cart.TotalPrice)
                {
                    customer.Wallet -= cart.TotalPrice;
                }
                else
                {
                    return Content("please charge your wallet");
                }

                foreach (var product in cart.Products)
                {
                    var booth = product.Booth;
                    var sellerId = booth.Seller.SellerId;
                    var seller = await _sellerAppServices.GetSellerById(sellerId, cancellation);
                    var medal = seller.Medal;
                    var Wage = product.Price * medal.WagePercentage / 100;
                    product.Amount -= 1;
                    if (product.Amount == 0)
                    {
                        await _productAppServices.DeleteProduct(product.ProductId, cancellation);
                    }
                    seller.Wallet += product.Price - Wage;

                    var wage = new WageDtOs
                    {
                        AdminId = 1,
                        Price = Wage,
                        SellerId = seller.SellerId,
                        ProductId = product.ProductId,
                    };

                    await _sellerAppServices.UpdateSeller(seller, cancellation);
                }

                
                await _customerAppServices.UpdateCustomer(customer, cancellation);
                await _cartAppServices.UpdateCart(cart, cancellation);

            }

            return RedirectToAction("CurrentCart", "CustomerPanel");
        }


    }
}