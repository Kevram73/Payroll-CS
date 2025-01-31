using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedProject
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Payroll System Upgrade",
                    Description = "Enhancing the payroll system for better efficiency and security.",
                    StartDate = new DateTime(2024, 1, 10),
                    EndDate = new DateTime(2024, 6, 30),
                    Budget = 50000.00m,
                    Status = "InProgress"
                },
                new Project
                {
                    Id = 2,
                    Name = "Employee Benefits Expansion",
                    Description = "Adding new benefits for employees, including healthcare and retirement plans.",
                    StartDate = new DateTime(2024, 3, 1),
                    EndDate = null, // Ongoing project
                    Budget = 75000.00m,
                    Status = "Pending"
                },
                new Project
                {
                    Id = 3,
                    Name = "Automated Tax Calculation",
                    Description = "Developing a system to automatically calculate tax deductions.",
                    StartDate = new DateTime(2023, 11, 1),
                    EndDate = new DateTime(2024, 2, 28),
                    Budget = 60000.00m,
                    Status = "Completed"
                },
                new Project
                {
                    Id = 4,
                    Name = "Automated Tax Calculation Hell",
                    Description = "Developing a system to automatically calculate tax deductions.",
                    StartDate = new DateTime(2023, 11, 1),
                    EndDate = new DateTime(2024, 2, 28),
                    Budget = 60000.00m,
                    Status = "Pending"
                }
            );
        }
    }
}