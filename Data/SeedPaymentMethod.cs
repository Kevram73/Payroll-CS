using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedPaymentMethod
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = 1,
                    Type = PaymentMethodType.BankTransfer,
                    BankName = "Bank of America",
                    AccountNumber = "123456789",
                    RoutingNumber = "987654321",
                    EmployeeId = 1
                },
                new PaymentMethod
                {
                    Id = 2,
                    Type = PaymentMethodType.DirectDeposit,
                    BankName = "Chase Bank",
                    AccountNumber = "234567891",
                    RoutingNumber = "876543219",
                    EmployeeId = 2
                },
                new PaymentMethod
                {
                    Id = 3,
                    Type = PaymentMethodType.Check,
                    BankName = "Wells Fargo",
                    AccountNumber = "345678912",
                    RoutingNumber = "765432198",
                    EmployeeId = 3
                },
                new PaymentMethod
                {
                    Id = 4,
                    Type = PaymentMethodType.Cash,
                    BankName = string.Empty,
                    AccountNumber = string.Empty,
                    RoutingNumber = string.Empty,
                    EmployeeId = 4
                }
            );
        }
    }
}