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
    public class AppRoleConfiguration: IEntityTypeConfiguration<AppRole>
    {

        public void Configure(EntityTypeBuilder<AppRole> entity)
        {
            entity.HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Discription = "Access to Everything"

                },
            new AppRole
            {
                Id = 2,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                Discription = "Access to Products"

            },
            new AppRole
            {
                Id = 3,
                Name = "Seller",
                NormalizedName = "SELLER",
                Discription = "Access to Selling Things"

            });
        }
    }
}
