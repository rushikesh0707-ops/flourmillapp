using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public AdminController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        // -------------------- Order Management --------------------

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound("Order not found");
            return Ok(order);
        }

        [HttpPut("orders/{orderId}/assign-delivery-boy")]
        public async Task<IActionResult> AssignDeliveryBoy(int orderId, [FromQuery] int deliveryBoyId)
        {
            var success = await _orderService.AssignDeliveryBoyAsync(orderId, deliveryBoyId);

            if (!success) return NotFound("Order not found");
            return Ok("Delivery boy assigned successfully.");
            return NoContent();
        }

        [HttpPut("orders/{orderId}/payment-status")]
        public async Task<IActionResult> UpdatePaymentStatus(int orderId, [FromQuery] bool isPaid)
        {
            var success = await _orderService.UpdatePaymentStatusAsync(orderId, isPaid);
            if (!success) return NotFound("Order not found");
            return Ok("Payment status updated successfully.");

        }

        // -------------------- Product Management --------------------

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok("Product added successfully.");
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            var success = await _productService.UpdateProductAsync(id, product);
            if (!success) return NotFound("Product not found");
            return Ok("Product updated successfully.");
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _productService.DeleteProductAsync(id);
            if (!success) return NotFound("Product not found");
            return Ok("Product deleted successfully.");
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
