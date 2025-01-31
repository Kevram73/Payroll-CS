using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedDeduction
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deduction>().HasData(
                new Deduction
                {
                    Id = 1,
                    EmployeeId = 1,
                    Type = DeductionType.Tax,
                    Amount = 300.00m,
                    DeductionDate = new DateTime(2024, 1, 5),
                    Description = "Impôt sur le revenu"
                },
                new Deduction
                {
                    Id = 2,
                    EmployeeId = 2,
                    Type = DeductionType.HealthInsurance,
                    Amount = 100.00m,
                    DeductionDate = new DateTime(2024, 1, 10),
                    Description = "Assurance santé"
                },
                new Deduction
                {
                    Id = 3,
                    EmployeeId = 3,
                    Type = DeductionType.Retirement,
                    Amount = 250.00m,
                    DeductionDate = new DateTime(2024, 1, 15),
                    Description = "Cotisation retraite"
                }
            );
        }
    }
}