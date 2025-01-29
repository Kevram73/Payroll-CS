using Payroll.Models;
using System.Threading.Tasks;

namespace Payroll.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetUserByIdAsync(string id);
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task AddUserAsync(AppUser user, string password);
        Task UpdateUserAsync(AppUser user);
        Task DeleteUserAsync(string id);
        Task<bool> LoginAsync(string email, string password);
    }
}
