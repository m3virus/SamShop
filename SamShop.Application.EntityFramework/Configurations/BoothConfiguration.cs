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
    public class BoothConfiguration : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> entity)
        {
            #region Entities

            entity.HasKey(b => b.BoothId);
            entity.Property(b => b.BoothId).ValueGeneratedOnAdd();

            entity.HasOne(b => b.Address)
                .WithOne(a => a.Booth)
                .HasForeignKey<Booth>(b => b.AddressId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Address_Booth");
            entity.HasData(GetBooth());

            #endregion

        }

        #region DataSeeder

        private List<Booth> GetBooth()
        {
            return Enumerable.Range(1, 2).Select(index => new Booth
            {
                BoothId = index,
                BoothName = $"booth {index}",
                AddressId = index + 4,
                IsDeleted = false,
                DeleteTime = null,
                CreateTime = DateTime.Now,


            }).ToList();
        }

        #endregion


    }
}
