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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            #region entities

            entity.HasKey(a => a.AddressId);
            entity.Property(a => a.AddressId).ValueGeneratedOnAdd();
            entity.Property(a => a.PostCode).HasMaxLength(10);
            entity.HasOne(x => x.Customer)
                .WithMany(x => x.Address)
                .HasForeignKey(x => x.CustomerId);
            entity.HasData(GetAddresses());
            #endregion

           
        }

        #region DataSeeder

        
        private List<Address> GetAddresses()
        {
            return Enumerable.Range(1, 10).Select(index => new Address
            {
                AddressId = index,
                State = $"State {index}",
                City = $"City {index}",
                Street = $"street {index}",
                Alley = $"alley {index}",
                ExtraPart = $"level 1",
                PostCode = $"{index * 1000}",
                


            }).ToList();
        }

        #endregion

    }
}
