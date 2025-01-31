using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedEmployeeProject
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    EmployeeId = 1,
                    ProjectId = 1
                },
                new EmployeeProject
                {
                    EmployeeId = 1,
                    ProjectId = 2
                },
                new EmployeeProject
                {
                    EmployeeId = 2,
                    ProjectId = 1
                },
                new EmployeeProject
                {
                    EmployeeId = 3,
                    ProjectId = 3
                },
                new EmployeeProject
                {
                    EmployeeId = 4,
                    ProjectId = 2
                },
                new EmployeeProject
                {
                    EmployeeId = 2,
                    ProjectId = 4
                }
            );
        }
    }
}