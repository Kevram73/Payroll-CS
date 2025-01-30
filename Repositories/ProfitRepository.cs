using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Interfaces;
using Payroll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Repositories
{
    public class ProfitRepository : IProfitRepository
    {
        private readonly PayrollDbContext _context;

        public ProfitRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profit>> GetAllProfitsAsync()
        {
            return await _context.Profits.OrderByDescending(p => p.CalculatedDate).ToListAsync();
        }

        public async Task<Profit?> GetLatestProfitAsync()
        {
            return await _context.Profits.OrderByDescending(p => p.CalculatedDate).FirstOrDefaultAsync();
        }

        public async Task AddProfitAsync(Profit profit)
        {
            await _context.Profits.AddAsync(profit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfitAsync(Profit profit)
        {
            _context.Profits.Update(profit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfitAsync(int id)
        {
            var profit = await _context.Profits.FindAsync(id);
            if (profit != null)
            {
                _context.Profits.Remove(profit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
