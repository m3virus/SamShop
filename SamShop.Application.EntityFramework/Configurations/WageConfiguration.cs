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
    public class WageConfiguration : IEntityTypeConfiguration<Wage>
    {

        public void Configure(EntityTypeBuilder<Wage> entity)
        {
            entity.HasKey(w => w.WageId);
            entity.Property(w => w.WageId).ValueGeneratedOnAdd();

            entity.Property(w => w.Price).HasPrecision(2);

            entity.HasOne(w => w.Product)
                .WithOne(p => p.Wage)
                .HasForeignKey<Wage>(w => w.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_Wage"); 

            entity.HasOne(w => w.Seller)
                .WithOne(s => s.Wage)
                .HasForeignKey<Wage>(w => w.SellerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Seller_Wage");

            entity.HasOne(w => w.Admin)
                .WithMany(s => s.Wages)
                .HasForeignKey(w => w.AdminId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Admin_Wage");
        }
    }
}
