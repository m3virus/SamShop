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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> entity)
        {
            #region Entities

            entity.HasKey(a => a.AdminId);
            entity.Property(e => e.AdminId).ValueGeneratedOnAdd();

            #endregion

            #region Relations

            entity.HasOne(a => a.Address)
                .WithOne(a => a.Admin)
                .HasForeignKey<Admin>(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Address_Admin");

            entity.HasOne(a => a.Picture)
                .WithOne(p => p.Admin)
                .HasForeignKey<Admin>(a => a.PictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Picture_Admin");

            entity.HasOne(a => a.Appuser)
                .WithOne(a => a.Admin)
                .HasForeignKey<Admin>(a => a.AppUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_AppUser_Admin");
            entity.HasData(GetAdmins());

            #endregion


        }
        #region DataSeeder

        private List<Admin> GetAdmins()
        {
            return Enumerable.Range(1, 1).Select(index => new Admin
            {
                AdminId = index,
                AddressId = 3,
                PictureId = null,
                Wallet = index * 100,
                IsDeleted = false,
                AppUserId = 1,
                DeleteTime = null,
                CreateTime = DateTime.Now
            }).ToList();
        }

        #endregion
    }
}
