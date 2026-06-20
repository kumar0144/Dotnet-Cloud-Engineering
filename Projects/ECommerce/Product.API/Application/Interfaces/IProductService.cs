using Product.API.Contracts.Requests;
using Product.API.Contracts.Responses;

namespace Product.API.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllAsync();

        Task<ProductResponse?> GetByIdAsync(int id);

        Task<ProductResponse> CreateAsync(
            CreateProductRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
