namespace FlourmillAPI.DTOs
{
    public class CheckoutDto
    {
        public int UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}
