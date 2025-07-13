using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlourmillAPI.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;
        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(PaymentDto dto)
        {
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                UserId = dto.UserId,
                Amount = dto.Amount,
                PaymentMode = dto.PaymentMode,
                Status = dto.Status
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> UpdateStatusAsync(int paymentId, string status)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null) return false;

            payment.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetUserPaymentsAsync(int userId)
        {
            return await _context.Payments
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}
