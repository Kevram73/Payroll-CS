using System;

namespace Payroll.Models
{
    public class Profit
    {
        public int Id { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfit => TotalRevenue - TotalExpenses;
        public DateTime CalculatedDate { get; set; } = DateTime.UtcNow;
    }
}
