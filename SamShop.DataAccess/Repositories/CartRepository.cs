using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly SamShopDbContext _context;

        public CartRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation)

        {
            Cart CartAdding = new Cart()
            {
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = false,
                IsPayed = false,
                CancelTime = null,
                CreateTime = DateTime.Now

            };
            await _context.Carts.AddAsync(CartAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CartAdding.CartId;
        }

        public IEnumerable<CartDtOs> GetAllCart()
        {
            var Carts = _context.Carts
                .Include(cart => cart.Products)!
                .ThenInclude(product => product.Pictures)
                .Include(cart => cart.Products)!
                .ThenInclude(product => product.Booth)
                .Include(cart => cart.Products)!
                .ThenInclude(product => product.Category);
            var CartDtOs = new List<CartDtOs>();

            foreach (var Cart in Carts)
            {
                if (Cart.Products != null)
                {
                    var a = new CartDtOs()
                    {
                        CartId = Cart.CartId,
                        TotalPrice = Cart.TotalPrice,
                        CustomerId = Cart.CustomerId,
                        IsCanceled = Cart.IsCanceled,
                        IsPayed = Cart.IsPayed,
                        CancelTime = Cart.CancelTime,
                        CreateTime = Cart.CreateTime,
                        Products = Cart.Products.Select(product => new Product
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Pictures = product.Pictures.Where(picture => picture.IsDeleted != true).Select(picture => new Picture
                            {
                                Url = picture.Url
                            }).ToList(),
                            Booth = new Booth
                            {
                                BoothId = product.Booth.BoothId,
                                BoothName = product.Booth.BoothName,
                            },
                            Category = new Category
                            {
                                CategoryId = product.Category.CategoryId,
                                CategoryName = product.Category.CategoryName,
                            }
                        }).ToList(),
                    };
                    CartDtOs.Add(a);
                }
            }

            return CartDtOs;
        }



        public async Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation)
        {
            var Cart = await _context.Carts
                .Include(cart => cart.Products)
                .ThenInclude(product => product.Pictures)
                .Include(cart => cart.Products)
                .ThenInclude(product => product.Category)
                .Include(cart => cart.Products)
                .ThenInclude(product => product.Booth)
                .ThenInclude(booth => booth.Seller)
                .ThenInclude(seller => seller.Medal)
                .FirstOrDefaultAsync(a => a.CartId == id, cancellation);

            var CartById = new CartDtOs()
            {
                CartId = Cart.CartId,
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = Cart.IsCanceled,
                IsPayed = Cart.IsPayed,
                CancelTime = Cart.CancelTime,
                CreateTime = Cart.CreateTime,
                Products = Cart.Products.Select(product => new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Amount = product.Amount,
                    Pictures = product.Pictures.Where(picture => picture.IsDeleted != true).Select(picture => new Picture
                    {
                        Url = picture.Url
                    }).ToList(),
                    Booth = new Booth
                    {
                        BoothId = product.BoothId,
                        BoothName = product.Booth.BoothName,
                        Seller = new Seller
                        {
                            SellerId = product.Booth.Seller.SellerId,
                            Wallet = product.Booth.Seller.Wallet,
                            Medal = new Medal
                            {
                                MedalId = product.Booth.Seller.Medal.MedalId,
                                WagePercentage = product.Booth.Seller.Medal.WagePercentage,
                            }
                        }
                    },
                    Category = new Category
                    {
                        CategoryId = product.Category.CategoryId,
                        CategoryName = product.Category.CategoryName,
                    }
                }).ToList(),

            };
            return CartById;

        }
        public async Task UpdateCart(CartDtOs Cart, CancellationToken cancellation)
        {
            Cart? changeCart = await _context.Carts
                .Include(cart => cart.Products)
                .FirstOrDefaultAsync(c => c.CartId == Cart.CartId, cancellation);
            var cartProductRelation = _context.CartProducts;
            if (changeCart != null)
            {
                changeCart.TotalPrice = Cart.TotalPrice;
                changeCart.IsCanceled = Cart.IsCanceled;
                changeCart.IsPayed = Cart.IsPayed;
                foreach (var productDto in Cart.Products)
                {
                    var existingProduct = Cart.Products.FirstOrDefault(p => p.ProductId == productDto.ProductId);
                    var check = new CartProducts
                    {
                        ProductsProductId = existingProduct.ProductId,
                        CartsCartId = Cart.CartId
                    };
                    if (cartProductRelation.Contains(check))
                    {
                        continue;
                    }
                    else
                    {
                        if (existingProduct != null)
                        {

                            var cartProducts = new CartProducts
                            {
                                CartsCartId = Cart.CartId,
                                ProductsProductId = existingProduct.ProductId,
                            };
                            _context.CartProducts.Add(cartProducts);
                            await _context.SaveChangesAsync(cancellation);
                        }
                    }

                }

            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCart(int id, CancellationToken cancellation)
        {
            Cart? removingCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id, cancellation);
            if (removingCart != null)
            {
                removingCart.IsCanceled = true;
                removingCart.CancelTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task DeleteProductFromCart(int cartId, int productId, CancellationToken cancellation)
        {
            var productCart = _context.CartProducts;
            var removeProduct = new CartProducts
            {
                ProductsProductId = productId,
                CartsCartId = cartId
            };
            if (productCart.Contains(removeProduct))
            {
                productCart.Remove(removeProduct);
                await _context.SaveChangesAsync(cancellation);
            }
        }

        public async Task AddCartForAuction(CartDtOs Cart, CancellationToken cancellation)
        {
            Cart CartAdding = new Cart()
            {
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = false,
                IsPayed = true,
                CancelTime = null,
                CreateTime = DateTime.Now

            };
            await _context.Carts.AddAsync(CartAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
