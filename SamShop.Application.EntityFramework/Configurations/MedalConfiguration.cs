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
    public class MedalConfiguration:IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> entity)
        {
            #region Entities

            entity.HasKey(m => m.MedalId);
            entity.Property(m => m.MedalId).ValueGeneratedOnAdd();

            entity.HasData(GetMedals());

            #endregion

        }

        #region DataSeeder

        private List<Medal> GetMedals()
        {
            return Enumerable.Range(1, 1).Select(index => new Medal
            {
                MedalId = index,
                MedalType = $"Medal {index}",
                IsDeleted = false,
                WagePercentage = index * 4,
                DeleteTime = null,
                CreateTime = DateTime.Now


            }).ToList();

        }

        #endregion
    }
}
