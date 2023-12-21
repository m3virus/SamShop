using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class AuctionRepository:IAuctionRepository
    {
        protected readonly SamShopDbContext _context;

        public AuctionRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation)

        {
            Auction AuctionAdding = new Auction()
            {
                AuctionTitle = Auction.AuctionTitle,
                TheLowestOffer = Auction.TheLowestOffer,
                ProductId = Auction.ProductId,
                SellerId = Auction.SellerId,
                StartTime = Auction.StartTime,
                EndTime = Auction.EndTime,
                IsAccepted = true,
                IsActive = false,
                CancelTime = null
                
                

            };
            await _context.Auctions.AddAsync(AuctionAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return AuctionAdding.AuctionId;
        }

        public IEnumerable<AuctionDtOs> GetAllAuction()
        {
            var Auctions = _context.Auctions
                .Include(Auction => Auction.Product)
                .ThenInclude(product => product.Pictures)
                .Include(Auction => Auction.Product)
                .ThenInclude(product => product.Booth)
                .Include(Auction => Auction.Product)
                .ThenInclude(product => product.Booth)
                .Include(auction => auction.Seller)
                .ThenInclude(seller => seller.Medal)
                .Include(auction => auction.AuctionOffers)
                .ThenInclude(auctionOffer => auctionOffer.Customer)
                .ThenInclude(customer => customer.AppUser);
            var AuctionDtOs = new List<AuctionDtOs>();

            foreach (var Auction in Auctions)
            {
                var a = new AuctionDtOs()
                {
                    AuctionId = Auction.AuctionId,
                    AuctionTitle = Auction.AuctionTitle,
                    TheLowestOffer = Auction.TheLowestOffer,
                    ProductId = Auction.ProductId,
                    SellerId = Auction.SellerId,
                    StartTime = Auction.StartTime,
                    EndTime = Auction.EndTime,
                    IsAccepted = Auction.IsAccepted,
                    IsActive = Auction.IsActive,
                    CancelTime = Auction.CancelTime,
                    Product = new Product
                    {
                        ProductId = Auction.ProductId,
                        ProductName = Auction.Product.ProductName,
                        Booth = new Booth
                        {
                            BoothName = Auction.Product.Booth.BoothName,
                        },
                        Pictures = Auction.Product.Pictures.Where(picture => picture.IsDeleted != true).Select(picture => new Picture
                        {
                            Url = picture.Url
                        }).ToList(),
                    },
                    AuctionOffers = Auction.AuctionOffers.Select(auctionOffer => new AuctionOffer
                    {
                        OfferId = auctionOffer.OfferId,
                        OfferValue = auctionOffer.OfferValue,
                        OfferTime = auctionOffer.OfferTime,
                        IsAccept = auctionOffer.IsAccept,
                        Customer = new Customer
                        {
                            CustomerId = auctionOffer.CustomerId,
                            AppUser = new AppUser
                            {
                                UserName = auctionOffer.Customer.AppUser.UserName,
                            }
                        }
                    }).OrderByDescending(x => x.OfferValue).ToList(),
                };
                AuctionDtOs.Add(a);
            }

            return AuctionDtOs;
        }



        public async Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation)
        {
            var Auction = await _context.Auctions.AsNoTracking()
                .Include(Auction => Auction.Product)
                .ThenInclude(product => product.Pictures)
                .Include(Auction => Auction.Product)
                .ThenInclude(product => product.Booth)
                .Include(auction => auction.Seller)
                .ThenInclude(seller => seller.Medal)
                .FirstOrDefaultAsync(a => a.AuctionId == id, cancellation);

            var AuctionById = new AuctionDtOs()
            {
                AuctionId = Auction.AuctionId,
                AuctionTitle = Auction.AuctionTitle,
                TheLowestOffer = Auction.TheLowestOffer,
                ProductId = Auction.ProductId,
                SellerId = Auction.SellerId,
                StartTime = Auction.StartTime,
                EndTime = Auction.EndTime,
                IsAccepted = Auction.IsAccepted,
                IsActive = Auction.IsActive,
                CancelTime = Auction.CancelTime,
                Seller = new Seller
                {
                    SellerId = Auction.Seller.SellerId,
                    Wallet = Auction.Seller.Wallet,
                    MedalId = Auction.Seller.MedalId,
                    Medal = new Medal
                    {
                        MedalId = Auction.Seller.MedalId,
                        MedalType = Auction.Seller.Medal.MedalType,
                        WagePercentage = Auction.Seller.Medal.WagePercentage,
                    }
                },
                Product = new Product
                {
                    ProductId = Auction.Product.ProductId,
                    BoothId = Auction.Product.BoothId,
                    ProductName = Auction.Product.ProductName,
                    Pictures = Auction.Product.Pictures.Select(picture => new Picture
                    {
                        Url = picture.Url
                    }).ToList(),
                    Booth = new Booth
                    {
                        BoothId = Auction.Product.Booth.BoothId,
                        BoothName = Auction.Product.Booth.BoothName,
                    }
                }
            };
            return AuctionById;

        }
        public async Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            Auction? changeAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == Auction.AuctionId, cancellation);
            if (changeAuction != null)
            {
                changeAuction.AuctionTitle = Auction.AuctionTitle;
                changeAuction.TheLowestOffer = Auction.TheLowestOffer;
                changeAuction.IsAccepted = Auction.IsAccepted;
                changeAuction.StartTime = Auction.StartTime;
                changeAuction.EndTime = Auction.EndTime;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAuction(int id, CancellationToken cancellation)
        {
            Auction? removingAuction = await _context.Auctions.FirstOrDefaultAsync(p => p.AuctionId == id, cancellation);
            if (removingAuction != null)
            {
                removingAuction.IsActive = false;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
