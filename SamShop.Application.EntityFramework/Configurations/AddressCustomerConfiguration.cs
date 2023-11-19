﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Infrastructure.EntityFramework.Configurations
{
    public class AddressCustomerConfiguration : IEntityTypeConfiguration<AddressCustomer>
    {
        public void Configure(EntityTypeBuilder<AddressCustomer> entity)
        {
            #region entities

            entity.HasKey(ac => ac.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();

            entity.HasOne(a => a.Customer)
                .WithMany(c => c.AddressCustomers)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Customer_AddressCustomer");
            entity.HasOne(ac => ac.Address)
                .WithMany(a => a.AddressCustomers)
                .HasForeignKey(ac => ac.AddressId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Address_AddressCustomer");
            entity.HasData(GetAddressCustomers());

            #endregion

        }

        #region DataSeeder

        private List<AddressCustomer> GetAddressCustomers()
        {
            return Enumerable.Range(1, 2).Select(index => new AddressCustomer()
            {
                Id = index,
                AddressId = index + 1,
                CustomerId = index,
            }).ToList();
        }

        #endregion

    }
}