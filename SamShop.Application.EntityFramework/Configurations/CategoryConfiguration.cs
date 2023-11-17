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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            #region Entities

            entity.HasKey(c => c.CategoryId);
            entity.Property(c => c.CategoryId).ValueGeneratedOnAdd();
            entity.HasData(GetCategories());

            #endregion

        }

        #region DataSeeder

        private List<Category> GetCategories()
        {
            return Enumerable.Range(1, 2).Select(index => new Category
            {
                CategoryId = index,
                CategoryName = $"category {index}",
                IsAccepted = true,
                CreateTime = DateTime.Now,
                DeleteTime = null,
                IsDeleted = false,


            }).ToList();

        }

        #endregion
    }
}
