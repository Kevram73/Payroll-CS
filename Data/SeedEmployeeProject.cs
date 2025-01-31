using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Models;

namespace Payroll.Data
{
    public class SeedEmployeeProject : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasData(
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
                    EmployeeId = 5,
                    ProjectId = 4
                }
            );
        }
    }
}