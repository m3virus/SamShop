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
    internal class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(c => c.CustomerId);
            entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();

            entity.Property(c => c.Wallet).HasPrecision(2);


            entity.HasOne(c => c.AppUser)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_AppUser_Customer"); ;

            entity.HasOne(c => c.Picture)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.PictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Picture_Customer"); ;
        }
    }
}
