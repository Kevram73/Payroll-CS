using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public interface IAttendanceRepository
    {
        // Get all attendance records
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();

        // Get an attendance record by ID
        Task<Attendance> GetAttendanceByIdAsync(int id);

        // Get all attendance records for a specific employee
        Task<IEnumerable<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId);

        // Add a new attendance record
        Task AddAttendanceAsync(Attendance attendance);

        // Update an existing attendance record
        Task UpdateAttendanceAsync(Attendance attendance);

        // Delete an attendance record by ID
        Task DeleteAttendanceAsync(int id);

        // Save changes to the database (if using Unit of Work pattern)
        Task SaveAsync();
    }
}