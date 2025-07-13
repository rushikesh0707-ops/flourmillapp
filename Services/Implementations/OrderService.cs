using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlourmillAPI.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();

            var users = await _context.Users.ToListAsync();
            return orders.Select(order => new OrderDto
            {
                OrderId = order.Id,
                UserId = order.UserId,
                UserName = users.FirstOrDefault(u => u.Id == order.UserId)?.FullName,
                Phone = users.FirstOrDefault(u => u.Id == order.UserId)?.Phone,
                Address = order.Address,
                TotalAmount = (double)order.TotalAmount,
                IsPaid = order.IsPaid,
                DeliveryBoyId = order.DeliveryBoyId,
                DeliveryBoyName = order.DeliveryBoyName,
                Items = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = (double)item.Price,
                    ImageUrl = item.ImageUrl
                }).ToList()
            });
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) return null;

            return new OrderDto
            {
                OrderId = order.Id,
                UserId = order.UserId,
                UserName = order.UserName,
                Address = order.Address,
                TotalAmount = (double)order.TotalAmount,
                IsPaid = order.IsPaid,
                DeliveryBoyId = order.DeliveryBoyId,
                DeliveryBoyName = order.DeliveryBoyName,
                Items = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = (double)item.Price,
                    ImageUrl = item.ImageUrl
                }).ToList()
            };
        }

        public async Task<bool> AssignDeliveryBoyAsync(int orderId, int deliveryBoyId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            var deliveryBoy = await _context.Users
       .Where(u => u.Id == deliveryBoyId && u.Role == Role.DeliveryBoy)
       .FirstOrDefaultAsync();

            if (deliveryBoy == null) return false;

            order.DeliveryBoyId = deliveryBoyId;
            order.DeliveryBoyName = deliveryBoy.FullName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePaymentStatusAsync(int orderId, bool isPaid)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            order.IsPaid = isPaid;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
