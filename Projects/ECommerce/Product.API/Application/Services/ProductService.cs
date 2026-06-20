using Microsoft.EntityFrameworkCore;
using Product.API.Application.Interfaces;
using Product.API.Contracts.Requests;
using Product.API.Contracts.Responses;
using Product.API.Infrastructure.Persistence;

namespace Product.API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {
            return await _context.Products
                .Select(x => new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    StockQuantity = x.StockQuantity,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<ProductResponse?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    StockQuantity = x.StockQuantity,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProductResponse> CreateAsync(
            CreateProductRequest request)
        {
            var product = new Product.API.Domain.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return false;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
