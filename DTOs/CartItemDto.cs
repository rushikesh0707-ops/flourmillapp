namespace FlourmillAPI.DTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Quantity { get; set; }
        public int UserId { get; set; }
    }
}
