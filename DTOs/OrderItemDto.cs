namespace FlourmillAPI.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
