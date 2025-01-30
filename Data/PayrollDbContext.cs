using Payroll.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Payroll.Data;

public class PayrollDbContext : IdentityDbContext<AppUser>
{
    public PayrollDbContext(DbContextOptions<PayrollDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Benefit> Benefits { get; set; }
    public DbSet<Deduction> Deductions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Models.Payroll> Payrolls { get; set; }
    public DbSet<SalaryStructure> SalaryStructures { get; set; }
    public DbSet<TaxInformation> TaxInformations { get; set; }
    public DbSet<ActivityLog> ActivityLogs { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Profit> Profits { get; set; }
    public DbSet<TaskEmployee> TaskEmployees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var hasher = new PasswordHasher<AppUser>();

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Kevin",
                LastName = "Brown",
                UserName = "kevram",
                NormalizedUserName = "KEVRAM",
                Email = "kevram@payroll.com",
                NormalizedEmail = "KEVRAM@PAYROLL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );
    
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.PaymentMethod)
            .WithOne(pm => pm.Employee)
            .HasForeignKey<PaymentMethod>(pm => pm.EmployeeId);
        
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.SalaryStructure)
            .WithOne(ss => ss.Employee)
            .HasForeignKey<SalaryStructure>(ss => ss.EmployeeId);
        
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.TaxInformation)
            .WithOne(ti => ti.Employee)
            .HasForeignKey<TaxInformation>(ti => ti.EmployeeId);

        modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);
    }
}
