using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FlourmillAPI.Models;
using Razorpay.Api;

namespace FlourmillAPI.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;
        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(CartItemDto dto)
        {
            var existing = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == dto.ProductId && c.UserId == dto.UserId);

            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
            }
            else
            {
                var item = new CartItem
                {
                    ProductId = dto.ProductId,
                    ProductName = dto.ProductName,
                    ImageUrl = dto.ImageUrl,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    UserId = dto.UserId
                };

                await _context.CartItems.AddAsync(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItemDto>> GetCartItemsAsync(int userId)
        {
            return await _context.CartItems
                .Where(c => c.UserId == userId)
                .Select(c => new CartItemDto
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    UserId = c.UserId
                })
                .ToListAsync();
        }

        public async Task UpdateCartItemAsync(CartItemDto dto)
        {
            var existing = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == dto.ProductId && c.UserId == dto.UserId);

            if (existing != null)
            {
                existing.Quantity = dto.Quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCartAsync(int productId, int userId)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckoutAsync(CheckoutDto dto)
        {
            var userId = dto.UserId;
            var address = dto.Address;
            var totalAmount = dto.TotalAmount;

            var cartItems = await _context.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                throw new Exception("Cart is empty");

            var order = new FlourmillAPI.Models.Order
            {
                UserId = userId,
                Address = address,
                TotalAmount = totalAmount,
                OrderDate = DateTime.UtcNow,
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.ProductName,
                    Quantity = ci.Quantity,
                    Price = (decimal)ci.Price,
                    
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }


    }
}
