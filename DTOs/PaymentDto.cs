namespace FlourmillAPI.DTOs
{
    public class PaymentDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public string? RazorpayPaymentId { get; set; }
    }
}
