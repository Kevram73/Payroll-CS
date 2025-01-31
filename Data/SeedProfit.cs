using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedProfit
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profit>().HasData(
                new Profit
                {
                    Id = 1,
                    TotalRevenue = 100000.00m,
                    TotalExpenses = 75000.00m,
                    CalculatedDate = new DateTime(2024, 1, 31)
                },
                new Profit
                {
                    Id = 2,
                    TotalRevenue = 120000.00m,
                    TotalExpenses = 80000.00m,
                    CalculatedDate = new DateTime(2024, 2, 29)
                },
                new Profit
                {
                    Id = 3,
                    TotalRevenue = 110000.00m,
                    TotalExpenses = 82000.00m,
                    CalculatedDate = new DateTime(2024, 3, 31)
                }
            );
        }
    }
}