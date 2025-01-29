using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payroll.Models;

namespace Payroll.Interfaces
{
    public interface IDepartmentRepository
    {
        // Get all departments
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        // Get a department by ID
        Task<Department> GetDepartmentByIdAsync(int id);

        // Get a department by name
        Task<Department> GetDepartmentByNameAsync(string name);

        // Add a new department
        Task AddDepartmentAsync(Department department);

        // Update an existing department
        Task UpdateDepartmentAsync(Department department);

        // Delete a department by ID
        Task DeleteDepartmentAsync(int id);

        // Save changes to the database (if using Unit of Work pattern)
        Task SaveAsync();
    }
}