using System;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public static class SeedTaskEmployee
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEmployee>().HasData(
                new TaskEmployee
                {
                    Id = 1,
                    Title = "Préparer le rapport financier",
                    Description = "Compiler les données de paie pour le rapport mensuel.",
                    EmployeeId = 1,
                    Status = "Pending",
                    DueDate = DateTime.UtcNow.AddDays(7)
                },
                new TaskEmployee
                {
                    Id = 2,
                    Title = "Mettre à jour les dossiers des employés",
                    Description = "Vérifier et mettre à jour les informations RH.",
                    EmployeeId = 2,
                    Status = "InProgress",
                    DueDate = DateTime.UtcNow.AddDays(5)
                },
                new TaskEmployee
                {
                    Id = 3,
                    Title = "Organiser une réunion de suivi",
                    Description = "Planifier une réunion avec l'équipe des ressources humaines.",
                    EmployeeId = 3,
                    Status = "Completed",
                    DueDate = DateTime.UtcNow.AddDays(-2)
                },
                new TaskEmployee
                {
                    Id = 4,
                    Title = "Configurer le nouveau logiciel de paie",
                    Description = "Installer et tester le logiciel de gestion de paie.",
                    EmployeeId = 4,
                    Status = "Pending",
                    DueDate = DateTime.UtcNow.AddDays(10)
                }
            );
        }
    }
}