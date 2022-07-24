using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(36);
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.ProductSize).WithMany().HasForeignKey(k => k.ProductSizeId);
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(k => k.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(k => k.ProductTypeId);
        }
    }
}