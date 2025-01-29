using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Repositories
{
    public class DeductionRepository : IDeductionRepository
    {
        private readonly PayrollDbContext _context;

        public DeductionRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deduction>> GetAllDeductionsAsync()
        {
            return await _context.Deductions.ToListAsync();
        }

        public async Task<Deduction> GetDeductionByIdAsync(int id)
        {
            return await _context.Deductions.FindAsync(id);
        }

        public async Task<IEnumerable<Deduction>> GetDeductionsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Deductions
                .Where(d => d.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddDeductionAsync(Deduction deduction)
        {
            await _context.Deductions.AddAsync(deduction);
            await SaveAsync();
        }

        public async Task UpdateDeductionAsync(Deduction deduction)
        {
            _context.Deductions.Update(deduction);
            await SaveAsync();
        }

        public async Task DeleteDeductionAsync(int id)
        {
            var deduction = await _context.Deductions.FindAsync(id);
            if (deduction != null)
            {
                _context.Deductions.Remove(deduction);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
