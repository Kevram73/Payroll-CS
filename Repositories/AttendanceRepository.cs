using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly PayrollDbContext _context;

        public AttendanceRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId)
        {
            return await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await SaveAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await SaveAsync();
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
