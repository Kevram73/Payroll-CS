using Payroll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Repositories
{
    public interface ITaskEmployeeRepository
    {
        Task<IEnumerable<TaskEmployee>> GetAllTasksAsync();
        Task<TaskEmployee?> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskEmployee task);
        Task UpdateTaskAsync(TaskEmployee task);
        Task DeleteTaskAsync(int id);
    }
}
