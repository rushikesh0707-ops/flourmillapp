﻿namespace FlourmillAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // FK to Order
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation
        public Order Order { get; set; } = null!;
        public string ImageUrl { get; set; }
    }
}
