﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.InventoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.OwnsMany(x => x.Operations, modelBuilder =>
            {
                modelBuilder.ToTable("InventoryOperations");
                modelBuilder.HasKey(x => x.Id);
                modelBuilder.Property(x => x.Description).HasMaxLength(1000);
                modelBuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });

           
        }
    }
}