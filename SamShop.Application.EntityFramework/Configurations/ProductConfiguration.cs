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
    public class ProductConfiguration :IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            #region Entities

            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.ProductId).ValueGeneratedOnAdd();


            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Category_Product"); ;

            entity.HasOne(p => p.Booth)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BoothId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Booth_Product");
            entity.HasData(GetProducts());

            #endregion

        }

        #region DataSeeder

        private List<Product> GetProducts()
        {
            return Enumerable.Range(1, 1).Select(index => new Product
            {
                ProductId = index,
                ProductName = $"Product {index}",
                CategoryId = index,
                Price = index * 6,
                BoothId = index,
                IsDeleted = false,
                DeleteTime = null,
                AddTime = DateTime.Now,
                IsAvailable = true,
                IsAccepted = false,
                Amount = 5,


            }).ToList();
        }

        #endregion
    }
}
