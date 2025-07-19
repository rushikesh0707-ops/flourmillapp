using FlourmillAPI.Models;

namespace FlourmillAPI.DTOs
{
    public class DeliveryBoyLoginDto
    {
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Password { get; set; } = "";

        public Role Role { get; set; }
    }
}
