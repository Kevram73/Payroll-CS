using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;
using Payroll.Interfaces;

namespace Payroll.Repositories
{
    public class TaxInformationRepository : ITaxInformationRepository
    {
        private readonly PayrollDbContext _context;

        public TaxInformationRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxInformation>> GetAllAsync()
        {
            return await _context.TaxInformations
                .Include(t => t.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task<TaxInformation> GetByIdAsync(int id)
        {
            return await _context.TaxInformations
                .Include(t => t.Employee) // Include Employee details
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaxInformation> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.TaxInformations
                .Include(t => t.Employee) // Include Employee details
                .FirstOrDefaultAsync(t => t.EmployeeId == employeeId);
        }

        public async Task AddAsync(TaxInformation taxInformation)
        {
            await _context.TaxInformations.AddAsync(taxInformation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaxInformation taxInformation)
        {
            _context.TaxInformations.Update(taxInformation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var taxInformation = await _context.TaxInformations.FindAsync(id);
            if (taxInformation != null)
            {
                _context.TaxInformations.Remove(taxInformation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
