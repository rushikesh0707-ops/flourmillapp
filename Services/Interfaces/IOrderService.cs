using FlourmillAPI.DTOs;
using FlourmillAPI.Models;

namespace FlourmillAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task<bool> AssignDeliveryBoyAsync(int orderId, int deliveryBoyId);
        Task<bool> UpdatePaymentStatusAsync(int orderId, bool isPaid);
        //Task<List<Order>> GetOrdersForDeliveryBoyAsync(int deliveryBoyId);

        Task<List<OrderDto>> GetOrdersForDeliveryBoyAsync(int deliveryBoyId);
        Task<bool> MarkOrderAsDeliveredAsync(int orderId, int deliveryBoyId);

    }
}
