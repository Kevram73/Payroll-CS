using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedPayment
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    EmployeeId = 1,
                    Amount = 1500.00m,
                    PaymentMethodId = 1,
                    PaymentDate = DateTime.UtcNow.AddDays(-7),
                    Status = "Paid"
                },
                new Payment
                {
                    Id = 2,
                    EmployeeId = 2,
                    Amount = 2000.00m,
                    PaymentMethodId = 2,
                    PaymentDate = DateTime.UtcNow.AddDays(-3),
                    Status = "Processed"
                },
                new Payment
                {
                    Id = 3,
                    EmployeeId = 3,
                    Amount = 1800.50m,
                    PaymentMethodId = null, // No payment method assigned yet
                    PaymentDate = DateTime.UtcNow,
                    Status = "Pending"
                }
            );
        }
    }
}