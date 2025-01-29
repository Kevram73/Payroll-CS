using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly PayrollDbContext _context;

        public PaymentMethodRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsByEmployeeIdAsync(int employeeId)
        {
            return await _context.PaymentMethods
                .Where(pm => pm.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsByTypeAsync(PaymentMethodType type)
        {
            return await _context.PaymentMethods
                .Where(pm => pm.Type == type)
                .ToListAsync();
        }

        public async Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await SaveAsync();
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
            await SaveAsync();
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
