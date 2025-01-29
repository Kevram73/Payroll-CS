using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payroll.Models;

namespace Payroll.Interfaces
{
    public interface IDeductionRepository
    {
        // Get all deductions
        Task<IEnumerable<Deduction>> GetAllDeductionsAsync();

        // Get a deduction by ID
        Task<Deduction> GetDeductionByIdAsync(int id);

        // Get all deductions for a specific employee
        Task<IEnumerable<Deduction>> GetDeductionsByEmployeeIdAsync(int employeeId);

        // Add a new deduction
        Task AddDeductionAsync(Deduction deduction);

        // Update an existing deduction
        Task UpdateDeductionAsync(Deduction deduction);

        // Delete a deduction by ID
        Task DeleteDeductionAsync(int id);

        // Save changes to the database (if using Unit of Work pattern)
        Task SaveAsync();
    }
}