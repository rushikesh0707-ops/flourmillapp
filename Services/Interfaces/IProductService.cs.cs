using FlourmillAPI.DTOs;
using FlourmillAPI.Models;

namespace FlourmillAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
