using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/deliveryboy")]
    public class DeliveryBoyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliveryBoyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DeliveryBoyLoginDto dto)
        {
            var deliveryBoy = _context.DeliveryBoys.FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);
            if (deliveryBoy == null)
                return Unauthorized("Invalid credentials");

            return Ok(deliveryBoy);
        }

        [HttpGet("{id}/orders")]
        public IActionResult GetAssignedOrders(int id)
        {
            var orders = _context.Orders
                .Where(o => o.AssignedDeliveryBoyId == id && !o.IsDelivered)
                .ToList();
            return Ok(orders);
        }

        [HttpPut("{deliveryBoyId}/orders/{orderId}/deliver")]
        public IActionResult MarkOrderDelivered(int deliveryBoyId, int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId && o.AssignedDeliveryBoyId == deliveryBoyId);
            if (order == null)
                return NotFound("Order not found or not assigned");

            order.IsDelivered = true;
            _context.SaveChanges();
            return Ok("Marked as delivered");
        }
    }

}
