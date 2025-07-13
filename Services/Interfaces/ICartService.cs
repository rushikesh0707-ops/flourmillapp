using FlourmillAPI.DTOs;

namespace FlourmillAPI.Services.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(CartItemDto dto);
        Task<List<CartItemDto>> GetCartItemsAsync(int userId);
        Task UpdateCartItemAsync(CartItemDto dto);
        Task RemoveFromCartAsync(int productId, int userId);
        Task CheckoutAsync(CheckoutDto dto);
    }
}
