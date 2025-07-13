namespace FlourmillAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty; // COD, Razorpay
        public string Status { get; set; } = "Pending"; // Paid / Pending

        public string? RazorpayPaymentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
