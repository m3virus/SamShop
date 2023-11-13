using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamShop.Infrastructure.EntityFramework.Configurations.IdentityDataSeeder
{
    public class AppUserAppRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> entity)
        {
            entity.HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1

                },
                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 2
                },
                new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 3
                });
        }
    }
}
