using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/admin/orders")]
    public class OrderController : ControllerBase
    {
        //    private readonly IOrderService _orderService;

        //    public OrderController(IOrderService orderService)
        //    {
        //        _orderService = orderService;
        //    }

        //    //// Get all orders
        //    //[HttpGet]
        //    //public async Task<IActionResult> GetAllOrders()
        //    //{
        //    //    var orders = await _orderService.GetAllOrdersAsync();
        //    //    return Ok(orders);
        //    //}

        //    // Get single order details by OrderId
        //    [HttpGet("{orderId}")]
        //    //public async Task<IActionResult> GetOrderById(int orderId)
        //    //{
        //    //    var order = await _orderService.GetOrderByIdAsync(orderId);
        //    //    if (order == null)
        //    //        return NotFound();

        //    //    return Ok(order);
        //    //}

        //    // Assign delivery boy to an order
        //    //[HttpPut("assign-delivery")]
        //    //public async Task<IActionResult> AssignDeliveryBoy([FromBody] AssignDeliveryBoyDto dto)
        //    //{
        //    //    var success = await _orderService.AssignDeliveryBoyAsync(dto.OrderId, dto.DeliveryBoyId);
        //    //    if (!success)
        //    //        return BadRequest("Failed to assign delivery boy.");

        //    //    return Ok(new { message = "Delivery boy assigned successfully." });
        //    //}

        //    // Update payment status
        //    //[HttpPut("payment-status")]
        //    //public async Task<IActionResult> UpdatePaymentStatus([FromBody] PaymentStatusDto dto)
        //    //{
        //    //    var success = await _orderService.UpdatePaymentStatusAsync(dto.OrderId, dto.IsPaid);
        //    //    if (!success)
        //    //        return BadRequest("Payment status update failed.");

        //    //    return Ok(new { message = "Payment status updated successfully." });
        //    //}
        //}
    }

}
