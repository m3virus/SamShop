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
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> entity)
        {
            #region Entities

            entity.HasKey(a => a.AuctionId);

            entity.HasOne(a => a.Product)
                .WithMany(p => p.Auctions)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_Auction");

            entity.HasOne(a => a.Seller)
                .WithMany(p => p.Auctions)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Seller_Auction");
            entity.HasData(GetAuctions());
            #endregion

        }

        #region DataSeeder

        private List<Auction> GetAuctions()
        {
            return Enumerable.Range(1, 1).Select(index => new Auction
            {
                AuctionId = index,
                ProductId = index,
                AuctionTitle = $"AuctionSample {index}",
                TheLowestOffer = index * 10,
                SellerId = index,
                IsAccepted = false,
                IsCanceled = false,
                StartTime = DateTime.Now,
                EndTime = DateTime.Today,

            }).ToList();

        }

        #endregion
    }
}
