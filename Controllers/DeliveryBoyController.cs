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
            var orders = await _orderService.GetOrdersForDeliveryBoyAsync(deliveryBoyId);
            return Ok(orders);
        }

        [HttpPut("{deliveryBoyId}/orders/{orderId}/mark-delivered")]
        public async Task<IActionResult> MarkOrderAsDelivered(int deliveryBoyId, int orderId)
        {
            var success = await _orderService.MarkOrderAsDeliveredAsync(orderId, deliveryBoyId);
            if (!success) return NotFound("Order not found or not assigned to this delivery boy.");
            return Ok("Order marked as delivered.");
        }
    }
}
