﻿using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Configurations
{
    public class BrandConfigs : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> brand)
        {
            brand.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
