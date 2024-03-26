using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CompanyAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.AgentName).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.AgentPhoneNubmber).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            //builder.HasMany(x => x.Customers)
            //    .WithOne(x => x.Company)
            //    .HasForeignKey(x => x.CompanyId);
        }
    }
}
