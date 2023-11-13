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
            entity.HasKey(m => m.MedalId);
            entity.Property(m => m.MedalId).ValueGeneratedOnAdd();

            entity.Property(m => m.WagePercentage).HasPrecision(2);
            



        }
    }
}
