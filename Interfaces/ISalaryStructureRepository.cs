namespace Payroll.Repositories
{
    using Payroll.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISalaryStructureRepository
    {
        Task<IEnumerable<SalaryStructure>> GetAllAsync();
        Task<SalaryStructure> GetByIdAsync(int id);
        Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(int employeeId);
        Task AddAsync(SalaryStructure salaryStructure);
        Task UpdateAsync(SalaryStructure salaryStructure);
        Task DeleteAsync(int id);
    }
}
