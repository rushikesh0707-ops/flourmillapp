using FlourmillAPI.DTOs;
using FlourmillAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // User or system creates a payment entry after checkout
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDto dto)
        {
            var payment = await _paymentService.AddPaymentAsync(dto);
            return Ok(payment);
        }

        // Admin or Razorpay webhook updates payment status to Paid
        [HttpPut("{paymentId}/status")]
        public async Task<IActionResult> UpdateStatus(int paymentId, [FromQuery] string status)
        {
            var updated = await _paymentService.UpdateStatusAsync(paymentId, status);
            if (!updated) return NotFound("Payment not found");
            return Ok("Status updated");
        }

        // Admin gets all payments
        [HttpGet("admin/all")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // User gets their own payment history
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPayments(int userId)
        {
            var payments = await _paymentService.GetUserPaymentsAsync(userId);
            return Ok(payments);
        }
    }

}
