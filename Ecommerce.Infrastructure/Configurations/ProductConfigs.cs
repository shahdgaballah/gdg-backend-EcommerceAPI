using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Configurations
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            product.Property(p => p.Price).HasColumnType("decimal(18,2)");

            product.HasOne(p => p.Type)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            product.HasOne(p => p.Brand) 
                .WithMany(b => b.Products) 
                .HasForeignKey(p => p.ProductBrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}

