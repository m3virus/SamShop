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
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.HasKey(c => c.CommentId);


            entity.HasOne(c => c.Customer)
                .WithOne(c => c.Comment)
                .HasForeignKey<Comment>(c => c.CustomerId)
                .HasConstraintName("Fk_Customer_Comment");

            entity.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Product_Comment");


        }
    }
}
