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
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> entity)
        {
            entity.HasKey(s => s.SellerId);
            entity.Property(s => s.SellerId).ValueGeneratedOnAdd();

            entity.Property(s => s.Wallet).HasPrecision(2);

            entity.HasOne(s => s.Address)
                .WithOne(a => a.Seller)
                .HasForeignKey<Seller>(s => s.AddressId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Address_Seller"); 

            entity.HasOne(s => s.Booth)
                .WithOne(b => b.Seller)
                .HasForeignKey<Seller>(s => s.BoothId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Booth_Seller");


            entity.HasOne(s => s.Medal)
                .WithOne(m => m.Seller)
                .HasForeignKey<Seller>(s => s.MedalId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Medal_Seller");

            entity.HasOne(s => s.Picture)
                .WithOne(p => p.Seller)
                .HasForeignKey<Seller>(s => s.PictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Picture_Seller");

            entity.HasOne(s => s.AppUser)
                .WithOne(a => a.Seller)
                .HasForeignKey<Seller>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_AppUser_Seller");
        }
    }
}
