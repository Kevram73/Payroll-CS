using Payroll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Interfaces
{
    public interface IProfitRepository
    {
        Task<IEnumerable<Profit>> GetAllProfitsAsync();
        Task<Profit?> GetLatestProfitAsync();
        Task AddProfitAsync(Profit profit);
        Task UpdateProfitAsync(Profit profit);
        Task DeleteProfitAsync(int id);
    }
}
