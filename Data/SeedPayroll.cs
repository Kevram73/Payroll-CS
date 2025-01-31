using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedPayroll
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payroll.Models.Payroll>().HasData(
                new Payroll.Models.Payroll
                {
                    Id = 1,
                    EmployeeId = 1,
                    PayPeriodStart = new DateTime(2024, 1, 1),
                    PayPeriodEnd = new DateTime(2024, 1, 15),
                    GrossSalary = 3000.00m,
                    TotalDeductions = 500.00m,
                    NetSalary = 2500.00m,
                    PaymentDate = new DateTime(2024, 1, 16),
                    Status = PayrollStatus.Paid
                },
                new Payroll.Models.Payroll
                {
                    Id = 2,
                    EmployeeId = 2,
                    PayPeriodStart = new DateTime(2024, 1, 16),
                    PayPeriodEnd = new DateTime(2024, 1, 31),
                    GrossSalary = 4000.00m,
                    TotalDeductions = 700.00m,
                    NetSalary = 3300.00m,
                    PaymentDate = new DateTime(2024, 2, 1),
                    Status = PayrollStatus.Processed
                },
                new Payroll.Models.Payroll
                {
                    Id = 3,
                    EmployeeId = 3,
                    PayPeriodStart = new DateTime(2024, 2, 1),
                    PayPeriodEnd = new DateTime(2024, 2, 15),
                    GrossSalary = 3500.00m,
                    TotalDeductions = 600.00m,
                    NetSalary = 2900.00m,
                    PaymentDate = new DateTime(2024, 2, 16),
                    Status = PayrollStatus.Pending
                }
            );
        }
    }
}