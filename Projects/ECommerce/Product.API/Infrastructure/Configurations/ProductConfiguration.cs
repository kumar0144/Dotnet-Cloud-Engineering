using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.API.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product.API.Domain.Product>
    {
        public void Configure(EntityTypeBuilder<Product.API.Domain.Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Property(x => x.StockQuantity)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);

            builder.Property(x => x.UpdatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }

    }
}
