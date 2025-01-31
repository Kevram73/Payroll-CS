using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedSalaryStructure
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaryStructure>().HasData(
                new SalaryStructure
                {
                    Id = 1,
                    EmployeeId = 1,
                    BasicSalary = 5000.00m,
                    HousingAllowance = 1500.00m,
                    TransportAllowance = 500.00m,
                    MedicalAllowance = 300.00m,
                    OtherAllowances = 200.00m,
                    EffectiveDate = new DateTime(2024, 1, 1)
                },
                new SalaryStructure
                {
                    Id = 2,
                    EmployeeId = 2,
                    BasicSalary = 6000.00m,
                    HousingAllowance = 1800.00m,
                    TransportAllowance = 600.00m,
                    MedicalAllowance = 400.00m,
                    OtherAllowances = 250.00m,
                    EffectiveDate = new DateTime(2024, 1, 1)
                },
                new SalaryStructure
                {
                    Id = 3,
                    EmployeeId = 3,
                    BasicSalary = 5500.00m,
                    HousingAllowance = 1700.00m,
                    TransportAllowance = 550.00m,
                    MedicalAllowance = 350.00m,
                    OtherAllowances = 225.00m,
                    EffectiveDate = new DateTime(2024, 2, 1)
                }
            );
        }
    }
}