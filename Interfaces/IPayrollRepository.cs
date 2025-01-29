namespace Payroll.Repositories
{
    using Payroll.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllAsync();
        Task<Payroll?> GetByIdAsync(int id);
        Task<IEnumerable<Payroll>> GetByEmployeeIdAsync(int employeeId);
        Task AddAsync(Payroll payroll);
        Task UpdateAsync(Payroll payroll);
        Task DeleteAsync(int id);
        Task<IEnumerable<Payroll>> GetByStatusAsync(PayrollStatus status);
    }
}
