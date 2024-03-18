﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.Size).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired(false);
        builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CompanyId);
    }
}