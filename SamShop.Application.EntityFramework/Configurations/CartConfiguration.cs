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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> entity)
        {
            #region Entities

            entity.HasKey(c => c.CartId);
            entity.Property(c => c.CartId).ValueGeneratedOnAdd();

            entity.HasOne(c => c.Customer)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.CustomerId)
                .HasConstraintName("Fk_Customer_Cart");

            entity.HasMany(x => x.Products)
                .WithMany(x => x.Carts)
                .UsingEntity(j => j.ToTable("CartProducts"));

            entity.HasData(GetCarts());

            #endregion

        }

        #region DataSeeder

        private List<Cart> GetCarts()
        {
            return Enumerable.Range(1, 2).Select(index => new Cart
            {
                CartId = index,
                TotalPrice = 0,
                CustomerId = index,
                IsCanceled = false,
                CancelTime = null,
                IsPayed = false,
                CreateTime = DateTime.Now


            }).ToList();

        }

        #endregion

    }
}
