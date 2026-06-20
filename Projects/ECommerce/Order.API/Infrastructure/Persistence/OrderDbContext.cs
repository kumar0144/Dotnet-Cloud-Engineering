using Microsoft.EntityFrameworkCore;
using Order.API.Domain;

namespace Order.API.Infrastructure.Persistence;

public class OrderDbContext : DbContext
{
    public OrderDbContext(
        DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order.API.Domain.Order> Orders => Set<Order.API.Domain.Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OrderDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}