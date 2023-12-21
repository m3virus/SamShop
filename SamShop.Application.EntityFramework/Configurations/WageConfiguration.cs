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
            #region Entities

            entity.HasKey(w => w.WageId);
            entity.Property(w => w.WageId).ValueGeneratedOnAdd();


            entity.HasOne(w => w.Product)
                .WithMany(p => p.Wage)
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_Wage");

            entity.HasOne(w => w.Seller)
                .WithMany(s => s.Wage)
                .HasForeignKey(w => w.SellerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Seller_Wage");

            entity.HasOne(w => w.Admin)
                .WithMany(s => s.Wages)
                .HasForeignKey(w => w.AdminId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Admin_Wage");
            entity.HasData(Getwages());

            #endregion

        }

        #region DataSeeder

        private List<Wage> Getwages()
        {
            return Enumerable.Range(1, 1).Select(index => new Wage()
            {
                WageId = index,
                IsDeleted = false,
                DeleteTime = null,
                PayTime = DateTime.Now,
                AdminId = 1,
                SellerId = index,
                ProductId = index,
                Price = index * 4

            }).ToList();
        }

        #endregion
    }
}
