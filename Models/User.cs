namespace FlourmillAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public required string Phone { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        User,
        Admin,
        DeliveryBoy
    }
}
