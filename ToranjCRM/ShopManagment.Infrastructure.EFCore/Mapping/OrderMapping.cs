using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(100).IsRequired();
            builder.Property(x => x.OrderStatus).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Discount).HasMaxLength(100).IsRequired();
            builder.Property(x => x.DiscountRate).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DeliveredDate).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Deposit).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FinallyPrice).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
