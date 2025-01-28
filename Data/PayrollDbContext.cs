using Payroll.Models;
using Microsoft.EntityFrameworkCore;

namespace Payroll.Data;

public class PayrollDbContext : DbContext
{
    public PayrollDbContext(DbContextOptions options) 
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the one-to-one relationship between Employee and PaymentMethod
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.PaymentMethod)
            .WithOne(pm => pm.Employee)
            .HasForeignKey<PaymentMethod>(pm => pm.EmployeeId); // Define foreign key
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.SalaryStructure)
            .WithOne(ss => ss.Employee)
            .HasForeignKey<SalaryStructure>(ss => ss.EmployeeId);
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.TaxInformation)
            .WithOne(ti => ti.Employee)
            .HasForeignKey<TaxInformation>(ti => ti.EmployeeId);
    }
}