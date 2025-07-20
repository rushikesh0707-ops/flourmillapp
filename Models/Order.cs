using FlourmillAPI.DTOs;

namespace FlourmillAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        // Navigation
        public List<OrderItem> OrderItems { get; set; } = new();

        public int OrderId { get; set; }
       
        public string? UserName { get; set; }         // Optional if you want to show user info
       
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }

        

        public int? AssignedDeliveryBoyId { get; set; }
 

        public int? DeliveryBoyId { get; set; } // This should be enough for assignment
        public string? DeliveryBoyName { get; set; }

        public bool IsDelivered { get; set; } = false;  // ✅ Tracks delivery status
        //public DateTime? OrderDate { get; set; }      //
        //
        public string Status { get; set; }

        public User User { get; set; }


    }
}
