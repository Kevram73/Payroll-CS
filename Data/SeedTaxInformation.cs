using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedTaxInformation
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxInformation>().HasData(
                new TaxInformation
                {
                    Id = 1,
                    EmployeeId = 1,
                    TaxIdentificationNumber = "TIN123456789",
                    FilingStatus = TaxFilingStatus.Single,
                    TaxWithholding = 500.00m,
                    Exemptions = 1000.00m
                },
                new TaxInformation
                {
                    Id = 2,
                    EmployeeId = 2,
                    TaxIdentificationNumber = "TIN987654321",
                    FilingStatus = TaxFilingStatus.MarriedFilingJointly,
                    TaxWithholding = 400.00m,
                    Exemptions = 1500.00m
                },
                new TaxInformation
                {
                    Id = 3,
                    EmployeeId = 3,
                    TaxIdentificationNumber = "TIN456789123",
                    FilingStatus = TaxFilingStatus.HeadOfHousehold,
                    TaxWithholding = 600.00m,
                    Exemptions = 1200.00m
                }
            );
        }
    }
}