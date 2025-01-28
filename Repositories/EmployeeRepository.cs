using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Interfaces;
using Payroll.Models;

namespace Payroll.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly PayrollDbContext _context;

    public EmployeeRepository(PayrollDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.SalaryStructure)
            .Include(e => e.PaymentMethod)
            .Include(e => e.TaxInformation)
            .ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.SalaryStructure)
            .Include(e => e.PaymentMethod)
            .Include(e => e.TaxInformation)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}