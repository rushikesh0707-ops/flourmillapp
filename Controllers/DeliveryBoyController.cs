using FlourmillAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/delivery")]
    public class DeliveryBoyController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public DeliveryBoyController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{deliveryBoyId}/orders")]
        public async Task<IActionResult> GetAssignedOrders(int deliveryBoyId)
        {
            try
            {
                var orders = await _orderService.GetOrdersForDeliveryBoyAsync(deliveryBoyId);

                if (orders == null || !orders.Any())
                    return NotFound("No orders assigned to this delivery boy.");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }


        [HttpPut("{deliveryBoyId}/orders/{orderId}/mark-delivered")]
        public async Task<IActionResult> MarkOrderAsDelivered(int deliveryBoyId, int orderId)
        {
            var success = await _orderService.MarkOrderAsDeliveredAsync(orderId, deliveryBoyId);
            if (!success) return NotFound("Order not found or not assigned to this delivery boy.");

            var updatedOrders = await _orderService.GetOrdersForDeliveryBoyAsync(deliveryBoyId);
            return Ok(updatedOrders); // ✅ return updated list with statuses
        }
    }
}
