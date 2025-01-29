using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public interface IPaymentMethodRepository
    {
        // Get all payment methods
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync();

        // Get a payment method by ID
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);

        // Get payment methods by employee ID
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsByEmployeeIdAsync(int employeeId);

        // Get payment methods by type
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsByTypeAsync(PaymentMethodType type);

        // Add a new payment method
        Task AddPaymentMethodAsync(PaymentMethod paymentMethod);

        // Update an existing payment method
        Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod);

        // Delete a payment method by ID
        Task DeletePaymentMethodAsync(int id);

        // Save changes to the database (if using Unit of Work pattern)
        Task SaveAsync();
    }
}