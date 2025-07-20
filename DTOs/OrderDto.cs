namespace FlourmillAPI.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }         // Optional if you want to show user info
        public string Address { get; set; }
        public double TotalAmount { get; set; }

        public string Phone { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? DeliveryBoyId { get; set; }
        public string? DeliveryBoyName { get; set; }

        public string? Status { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
