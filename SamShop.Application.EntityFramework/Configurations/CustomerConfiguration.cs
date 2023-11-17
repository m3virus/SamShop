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
            #region Entities

            entity.HasKey(c => c.CustomerId);
            entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();



            entity.HasOne(c => c.AppUser)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_AppUser_Customer"); ;

            entity.HasOne(c => c.Picture)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.PictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Picture_Customer");
            entity.HasData(GetCustomer());

            #endregion

        }

        #region DataSeeder

        private List<Customer> GetCustomer()
        {
            return Enumerable.Range(1, 2).Select(index => new Customer
            {
                CustomerId = index,
                Wallet = index * 10,
                PictureId = null,
                AppUserId = index + 1,
                IsDeleted = false,
                DeleteTime = null,
                CreateTime = DateTime.Now,
                
            }).ToList();

        }

        #endregion

    }
}
