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
    internal class ProductCartConfiguration :IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> entity)
        {
            #region Entities

            entity.HasKey(pc => pc.Id);

            entity.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCarts)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_ProductCart"); ;

            entity.HasOne(pc => pc.Cart)
                .WithMany(p => p.ProductCarts)
                .HasForeignKey(pc => pc.CartId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Cart_ProductCart");
            entity.HasData(GetProductCarts());

            #endregion

        }

        #region DataSeeder

        private List<ProductCart> GetProductCarts()
        {
            return Enumerable.Range(1, 2).Select(index => new ProductCart()
            {
                Id = index,
                CartId = index,
                ProductId = index,


            }).ToList();
        }

        #endregion
    }
}
