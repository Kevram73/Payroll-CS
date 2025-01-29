using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;
using Payroll.Interfaces;

namespace Payroll.Repositories
{
    public class SalaryStructureRepository : ISalaryStructureRepository
    {
        private readonly PayrollDbContext _context;

        public SalaryStructureRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalaryStructure>> GetAllAsync()
        {
            return await _context.SalaryStructures
                .Include(s => s.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task<SalaryStructure> GetByIdAsync(int id)
        {
            return await _context.SalaryStructures
                .Include(s => s.Employee) // Include Employee details
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.SalaryStructures
                .Where(s => s.EmployeeId == employeeId)
                .Include(s => s.Employee) // Include Employee details
                .ToListAsync();
        }

        public async Task AddAsync(SalaryStructure salaryStructure)
        {
            await _context.SalaryStructures.AddAsync(salaryStructure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SalaryStructure salaryStructure)
        {
            _context.SalaryStructures.Update(salaryStructure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var salaryStructure = await _context.SalaryStructures.FindAsync(id);
            if (salaryStructure != null)
            {
                _context.SalaryStructures.Remove(salaryStructure);
                await _context.SaveChangesAsync();
            }
        }
    }
}
