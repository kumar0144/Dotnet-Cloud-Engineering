using Order.API.Contracts.Requests;
using Order.API.Contracts.Responses;

namespace Order.API.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllAsync();

        Task<OrderResponse?> GetByIdAsync(Guid id);

        Task<OrderResponse> CreateAsync(CreateOrderRequest request);

        Task<bool> DeleteAsync(Guid id);
    }
}
