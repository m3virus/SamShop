using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.AuctionDtOs;
using SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class AuctionServices:IAuctionServices
    {
        protected readonly IAuctionRepository _auctionRepository;
        protected readonly IAuctionOfferRepository _auctionOfferRepository;
        protected readonly IAdminRepository _adminRepository;
        protected readonly IWageRepository _wageRepository;
        protected readonly ICartRepository _cartRepository;

        public AuctionServices(IAuctionRepository auctionRepository, IAuctionOfferRepository auctionOfferRepository, IAdminRepository adminRepository, IWageRepository wageRepository, ICartRepository cartRepository)
        {
            _auctionRepository = auctionRepository;
            _auctionOfferRepository = auctionOfferRepository;
            _adminRepository = adminRepository;
            _wageRepository = wageRepository;
            _cartRepository = cartRepository;
        }


        public async Task<AuctionDtOs?> GetAuctionById(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuctionById(id, cancellation);
        }

        public async Task<int> AddAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
            return await _auctionRepository.AddAuction(Auction, cancellation);
        }

        public async Task UpdateAuction(AuctionDtOs Auction, CancellationToken cancellation)
        {
             await _auctionRepository.UpdateAuction(Auction, cancellation);
        }

        public async Task DeleteAuction(int id, CancellationToken cancellation)
        { 
            await _auctionRepository.DeleteAuction(id, cancellation);
        }

        public async Task StartAuction(int id, CancellationToken cancellation)
        {
            var auction = await _auctionRepository.GetAuctionById(id, cancellation);
            if (auction != null)
            {
                auction.IsActive = true;
                await _auctionRepository.UpdateAuction(auction, cancellation);
            }
            
        }

        public async Task EndAuction(int id, CancellationToken cancellation)
        {
            var auction = await _auctionRepository.GetAuctionById(id, cancellation);
            var admin = await _adminRepository.GetAdminById(1, cancellation);
            if (auction != null)
            {
                auction.IsActive = false;
                if (auction.AuctionOffers != null)
                {
                    var auctionOffer = auction.AuctionOffers.Select(AuctionOffers => new AuctionOfferDtOs
                        {
                            IsAccept = true

                        }).OrderByDescending(auction => auction.OfferValue)
                        .FirstOrDefault();

                    var offerWage = auctionOffer.OfferValue * auction.Seller.Medal.WagePercentage / 100;
                    auction.Seller.Wallet += auctionOffer.OfferValue - offerWage;
                    admin.Wallet += offerWage;

                    var wageInTable = new WageDtOs
                    {
                        Price = offerWage,
                        AdminId = 1,
                        SellerId = auction.Seller.SellerId,
                        ProductId = auction.Product.ProductId,
                    };
                    var cartInTable = new CartDtOs
                    {
                        CustomerId = auctionOffer.CustomerId,
                        TotalPrice = auctionOffer.OfferValue,
                    };
                    await _cartRepository.AddCartForAuction(cartInTable, cancellation);
                    await _wageRepository.AddWage(wageInTable, cancellation);
                    await _auctionRepository.UpdateAuction(auction, cancellation);
                    await _auctionOfferRepository.UpdateAuctionOffer(auctionOffer, cancellation);
                }
                else
                {
                    await _auctionRepository.UpdateAuction(auction, cancellation);
                }
            }
        }

        IEnumerable<AuctionDtOs> IAuctionServices.GetAllAuction()
        {
            return _auctionRepository.GetAllAuction();
        }

    }
}
