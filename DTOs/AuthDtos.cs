using FlourmillAPI.Models;

namespace FlourmillAPI.DTOs
{
    public class RegisterDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public required string Phone { get; set; }
        public Role Role { get; set; } = Role.User;
    }

    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AuthResponseDto
    {
        public required string Token { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public Role Role { get; set; }

        public int UserId { get; set; }
    }
}
