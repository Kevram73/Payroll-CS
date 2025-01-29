using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public interface IBenefitRepository
    {
        // Get all benefits
        Task<IEnumerable<Benefit>> GetAllBenefitsAsync();

        // Get a benefit by ID
        Task<Benefit> GetBenefitByIdAsync(int id);

        // Get all benefits for a specific employee
        Task<IEnumerable<Benefit>> GetBenefitsByEmployeeIdAsync(int employeeId);

        // Add a new benefit
        Task AddBenefitAsync(Benefit benefit);

        // Update an existing benefit
        Task UpdateBenefitAsync(Benefit benefit);

        // Delete a benefit by ID
        Task DeleteBenefitAsync(int id);

        // Save changes to the database (if using Unit of Work pattern)
        Task SaveAsync();
    }
}