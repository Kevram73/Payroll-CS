using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Models;

namespace Payroll.Data
{
    public class SeedDepartment : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "Ressources Humaines",
                    Description = "Gestion des employés et des ressources humaines."
                },
                new Department
                {
                    Id = 2,
                    Name = "Informatique",
                    Description = "Développement, maintenance et support IT."
                },
                new Department
                {
                    Id = 3,
                    Name = "Finance",
                    Description = "Gestion des finances et des budgets."
                },
                new Department
                {
                    Id = 4,
                    Name = "Marketing",
                    Description = "Publicité et stratégies de croissance."
                },
                new Department
                {
                    Id = 5,
                    Name = "Ventes",
                    Description = "Développement des ventes et gestion des clients."
                }
            );
        }
    }
}