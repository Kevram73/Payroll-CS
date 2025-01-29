namespace Payroll.Interfaces
{
    using Payroll.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaxInformationRepository
    {
        Task<IEnumerable<TaxInformation>> GetAllAsync();
        Task<TaxInformation> GetByIdAsync(int id);
        Task<TaxInformation> GetByEmployeeIdAsync(int employeeId);
        Task AddAsync(TaxInformation taxInformation);
        Task UpdateAsync(TaxInformation taxInformation);
        Task DeleteAsync(int id);
    }
}
