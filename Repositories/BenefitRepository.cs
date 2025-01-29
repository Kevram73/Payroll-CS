using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Repositories
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly PayrollDbContext _context;

        public BenefitRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Benefit>> GetAllBenefitsAsync()
        {
            return await _context.Benefits.ToListAsync();
        }

        public async Task<Benefit> GetBenefitByIdAsync(int id)
        {
            return await _context.Benefits.FindAsync(id);
        }

        public async Task<IEnumerable<Benefit>> GetBenefitsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Benefits
                .Where(b => b.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddBenefitAsync(Benefit benefit)
        {
            await _context.Benefits.AddAsync(benefit);
            await SaveAsync();
        }

        public async Task UpdateBenefitAsync(Benefit benefit)
        {
            _context.Benefits.Update(benefit);
            await SaveAsync();
        }

        public async Task DeleteBenefitAsync(int id)
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit != null)
            {
                _context.Benefits.Remove(benefit);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
