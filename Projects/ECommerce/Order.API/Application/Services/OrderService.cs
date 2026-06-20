using Microsoft.EntityFrameworkCore;
using Order.API.Application.Interfaces;
using Order.API.Contracts.Requests;
using Order.API.Contracts.Responses;
using Order.API.Domain;
using Order.API.Infrastructure.Persistence;

namespace Order.API.Application.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;

    public OrderService(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllAsync()
    {
        return await _context.Orders
            .AsNoTracking()
            .Select(x => new OrderResponse
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                CustomerName = x.CustomerName,
                CustomerEmail = x.CustomerEmail,
                TotalAmount = x.TotalAmount,
                Status = x.Status
            })
            .ToListAsync();
    }

    public async Task<OrderResponse?> GetByIdAsync(Guid id)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null)
            return null;

        return new OrderResponse
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var order = new Domain.Order
        {
            Id = Guid.NewGuid(),
            OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}",
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            Status = "Pending",
            OrderDate = DateTime.UtcNow
        };

        decimal totalAmount = 0;

        foreach (var item in request.Items)
        {
            var totalPrice = item.UnitPrice * item.Quantity;

            order.Items.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = totalPrice
            });

            totalAmount += totalPrice;
        }

        order.TotalAmount = totalAmount;

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        return new OrderResponse
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null)
        {
            return false;
        }

        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();

        return true;
    }
}