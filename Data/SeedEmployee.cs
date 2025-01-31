using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedEmployee
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Jean",
                    LastName = "Dupont",
                    Email = "jean.dupont@example.com",
                    Phone = "0612345678",
                    HireDate = new DateTime(2020, 5, 10),
                    DepartmentId = 1,
                    SalaryStructureId = 1,
                    PaymentMethodId = 1,
                    TaxInformationId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Marie",
                    LastName = "Curie",
                    Email = "marie.curie@example.com",
                    Phone = "0623456789",
                    HireDate = new DateTime(2019, 3, 15),
                    DepartmentId = 2,
                    SalaryStructureId = 2,
                    PaymentMethodId = 2,
                    TaxInformationId = 2
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Albert",
                    LastName = "Einstein",
                    Email = "albert.einstein@example.com",
                    Phone = "0634567890",
                    HireDate = new DateTime(2021, 7, 20),
                    DepartmentId = 3,
                    SalaryStructureId = 3,
                    PaymentMethodId = 3,
                    TaxInformationId = 3
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Isaac",
                    LastName = "Newton",
                    Email = "isaac.newton@example.com",
                    Phone = "0645678901",
                    HireDate = new DateTime(2018, 11, 5),
                    DepartmentId = 4,
                    SalaryStructureId = 4,
                    PaymentMethodId = 4,
                    TaxInformationId = 4
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    Email = "ada.lovelace@example.com",
                    Phone = "0656789012",
                    HireDate = new DateTime(2022, 1, 10),
                    DepartmentId = 5,
                    SalaryStructureId = 5,
                    PaymentMethodId = 5,
                    TaxInformationId = 5
                }
            );
        }
    }
}
