using FlourmillAPI.DTOs;
using FlourmillAPI.Models;

namespace FlourmillAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> AddPaymentAsync(PaymentDto dto);
        Task<bool> UpdateStatusAsync(int paymentId, string status);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<IEnumerable<Payment>> GetUserPaymentsAsync(int userId);
    }
}
