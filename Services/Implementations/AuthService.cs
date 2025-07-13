using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Helpers;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FlourmillAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email already registered");

            var hashed = HashPassword(dto.Password);

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = hashed,
                Role = dto.Role,
                Phone = dto.Phone
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = JwtHelper.GenerateToken(user, _config["Jwt:Key"]!);

            return new AuthResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            var token = JwtHelper.GenerateToken(user, _config["Jwt:Key"]!);

            return new AuthResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string input, string hash)
        {
            return HashPassword(input) == hash;
        }
    }
}
