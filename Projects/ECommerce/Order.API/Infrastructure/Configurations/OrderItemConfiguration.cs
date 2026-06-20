using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.API.Domain;

namespace Order.API.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.UnitPrice)
                   .HasPrecision(18, 2);

            builder.Property(x => x.TotalPrice)
                   .HasPrecision(18, 2);

            builder.Property(x => x.CreatedOn)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedOn)
                   .IsRequired(false);
        }

    }
}
