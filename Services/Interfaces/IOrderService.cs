using FlourmillAPI.DTOs;

namespace FlourmillAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task<bool> AssignDeliveryBoyAsync(int orderId, int deliveryBoyId);
        Task<bool> UpdatePaymentStatusAsync(int orderId, bool isPaid);
    }
}
