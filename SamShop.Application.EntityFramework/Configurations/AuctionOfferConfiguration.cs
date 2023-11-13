using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Infrastructure.EntityFramework.Configurations
{
    public class AuctionOfferConfiguration : IEntityTypeConfiguration<AuctionOffer>
    {
        public void Configure(EntityTypeBuilder<AuctionOffer> entity)
        {
            entity.HasKey(a => a.OfferId);
            entity.Property(a => a.OfferId).ValueGeneratedOnAdd();

            entity.Property(a => a.OfferValue).HasPrecision(2);

            entity.HasOne(a => a.Auction)
                .WithMany(a => a.AuctionOffers)
                .HasForeignKey(a => a.AuctionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Auction_AuctionOffer");

            entity.HasOne(a => a.Customer)
                .WithMany(a => a.AuctionOffers)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Customer_AuctionOffer");
        }
        //private List<AuctionOffer> GetAuctionOffers()
        //{
        //    return Enumerable.Range(1, 3).Select(index => new AuctionOffer
        //    {
        //        OfferId = index,
        //        AuctionId = 1,
        //        OfferValue = index * 11,
        //        CustomerId = index,
        //        IsCanceled = false,
        //        IsAccept = false,


        //    }).ToList();
        }
}
