using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly PayrollDbContext _context;

        public PayrollRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Payroll>> GetAllAsync()
        {
            return await _context.Payrolls
                .Include(p => p.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task<Models.Payroll?> GetByIdAsync(int id)
        {
            return await _context.Payrolls
                .Include(p => p.Employee) // Include Employee details
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Models.Payroll>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.Payrolls
                .Where(p => p.EmployeeId == employeeId)
                .Include(p => p.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Payroll>> GetByStatusAsync(PayrollStatus status)
        {
            return await _context.Payrolls
                .Where(p => p.Status == status)
                .Include(p => p.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task AddAsync(Models.Payroll payroll)
        {
            await _context.Payrolls.AddAsync(payroll);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Models.Payroll payroll)
        {
            _context.Payrolls.Update(payroll);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll != null)
            {
                _context.Payrolls.Remove(payroll);
                await _context.SaveChangesAsync();
            }
        }
    }
}
