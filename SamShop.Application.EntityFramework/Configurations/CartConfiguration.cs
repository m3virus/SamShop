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
            entity.HasKey(c => c.CartId);
            entity.Property(c => c.CartId).ValueGeneratedOnAdd();

            entity.Property(c => c.TotalPrice).HasPrecision(2);

            entity.HasOne(c => c.Customer)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.CustomerId)
                .HasConstraintName("Fk_Customer_Cart");
        }
    }
}
