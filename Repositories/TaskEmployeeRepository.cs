using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Repositories
{
    public class TaskEmployeeRepository : ITaskEmployeeRepository
    {
        private readonly PayrollDbContext _context;

        public TaskEmployeeRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskEmployee>> GetAllTasksAsync()
        {
            return await _context.TaskEmployees.Include(t => t.Employee).ToListAsync();
        }

        public async Task<TaskEmployee?> GetTaskByIdAsync(int id)
        {
            return await _context.TaskEmployees.Include(t => t.Employee).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTaskAsync(TaskEmployee task)
        {
            await _context.TaskEmployees.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskEmployee task)
        {
            _context.TaskEmployees.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.TaskEmployees.FindAsync(id);
            if (task != null)
            {
                _context.TaskEmployees.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
