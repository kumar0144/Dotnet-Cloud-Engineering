using Microsoft.EntityFrameworkCore;
using Product.API.Domain;
using System.Reflection.Emit;

namespace Product.API.Infrastructure.Persistence
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(
        DbContextOptions<ProductDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product.API.Domain.Product> Products => Set<Product.API.Domain.Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ProductDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
