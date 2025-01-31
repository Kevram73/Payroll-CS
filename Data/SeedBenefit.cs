using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Models;
using System;

namespace Payroll.Data
{
    public class SeedBenefit : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.HasData(
                new Benefit
                {
                    Id = 1,
                    EmployeeId = 1,
                    Type = BenefitType.Bonus,
                    Amount = 500.00m,
                    BenefitDate = new DateTime(2024, 1, 1),
                    Description = "Prime de performance annuelle"
                },
                new Benefit
                {
                    Id = 2,
                    EmployeeId = 2,
                    Type = BenefitType.Overtime,
                    Amount = 200.00m,
                    BenefitDate = new DateTime(2024, 1, 10),
                    Description = "Heures supplémentaires"
                },
                new Benefit
                {
                    Id = 3,
                    EmployeeId = 3,
                    Type = BenefitType.Allowance,
                    Amount = 150.00m,
                    BenefitDate = new DateTime(2024, 1, 15),
                    Description = "Indemnité de transport"
                }
            );
        }
    }
}