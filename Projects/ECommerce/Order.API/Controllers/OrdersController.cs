using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.API.Application.Interfaces;
using Order.API.Contracts.Requests;
using Order.API.Contracts.Responses;

namespace Order.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync();

        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateOrderRequest request)
    {
        var order = await _orderService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = order.Id },
            order);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _orderService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                Message = $"Order '{id}' not found."
            });
        }

        return Ok(new
        {
            Message = "Order deleted successfully."
        });
    }
}