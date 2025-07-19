using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
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
            var deliveryBoy = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email && u.PasswordHash == dto.Password && u.Role == Role.DeliveryBoy);

            if (deliveryBoy == null)
                return Unauthorized("Invalid credentials or not a delivery boy");

            var response = new LoginResponseDto
            {
                Id = deliveryBoy.Id,
                FullName = deliveryBoy.FullName,
                Email = deliveryBoy.Email,
                Role = deliveryBoy.Role.ToString(),
                Phone = deliveryBoy.Phone,
            };

            return Ok(response);
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
