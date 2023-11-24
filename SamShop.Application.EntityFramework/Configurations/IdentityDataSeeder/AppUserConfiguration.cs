using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Infrastructure.EntityFramework.Configurations.IdentityDataSeeder
{
    public class AppUserConfiguration: IEntityTypeConfiguration<AppUser>
    {
        protected readonly UserManager<AppUser> _userManager;
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            

            var admin = new AppUser
            {
                Id = 1,
                UserName = "M3Virus",
                FirstName = "Mohammadhasan",
                LastName = "Yazdani",
                PhoneNumber = "0912345678",
                PhoneNumberConfirmed = true,
                Email = "m3virus@mail.com",
                EmailConfirmed = true,
                NormalizedUserName = "M3VIRUS",
                RegisterTime = DateTime.Now,
                IsDeleted = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var customer1 = new AppUser
            {
                Id = 2,
                UserName = "customer1",
                FirstName = "cust",
                LastName = "omer",
                PhoneNumber = "0912345678",
                PhoneNumberConfirmed = true,
                Email = "Customer2@mail.com",
                EmailConfirmed = true,
                NormalizedUserName = "CUSTOMER1",
                RegisterTime = DateTime.Now,
                IsDeleted = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var customer2 = new AppUser
            {
                Id = 3,
                UserName = "customer2",
                FirstName = "cust",
                LastName = "omer",
                PhoneNumber = "0912345678",
                PhoneNumberConfirmed = true,
                Email = "Customer2@mail.com",
                EmailConfirmed = true,
                NormalizedUserName = "CUSTOMER2",
                RegisterTime = DateTime.Now,
                IsDeleted = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var seller1 = new AppUser
            {
                Id = 4,
                UserName = "Seller1",
                FirstName = "sel",
                LastName = "ler",
                PhoneNumber = "0912345678",
                PhoneNumberConfirmed = true,
                Email = "Seller1@mail.com",
                EmailConfirmed = true,
                NormalizedUserName = "Seller1",
                RegisterTime = DateTime.Now,
                IsDeleted = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                
            };

            PasswordHasher<AppUser> password = new PasswordHasher<AppUser>();
                admin.PasswordHash = password.HashPassword(admin , "1234");
                customer1.PasswordHash = password.HashPassword(customer1 , "1234");
                customer2.PasswordHash = password.HashPassword(customer2 , "1234");
                seller1.PasswordHash = password.HashPassword(seller1 , "1234");
                entity.HasData(admin, customer1, customer2, seller1);

        }
        
    }
    
}
