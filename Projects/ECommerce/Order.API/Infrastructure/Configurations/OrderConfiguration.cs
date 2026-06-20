using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.API.Domain;

namespace Order.API.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order.API.Domain.Order>
    {
        public void Configure(EntityTypeBuilder<Order.API.Domain.Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CustomerName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CustomerEmail)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                   .HasMaxLength(50);

            builder.Property(x => x.OrderDate)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.CreatedOn)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedOn)
                   .IsRequired(false);

            builder.HasMany(x => x.Items)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
