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
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> entity)
        {
            #region Entities

            entity.HasKey(p => p.PictureId);
            entity.Property(p => p.PictureId).ValueGeneratedOnAdd();



            entity.HasOne(p => p.Product)
                .WithMany(p => p.Pictures)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_Picture");

            #endregion

        }
    }
}
