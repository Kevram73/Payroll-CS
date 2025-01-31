namespace Payroll.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public int DepartmentId { get; set; }
    public int SalaryStructureId { get; set; }
    public int PaymentMethodId { get; set; }
    public int TaxInformationId { get; set; }

    // Navigation properties
    public Department Department { get; set; }
    public SalaryStructure SalaryStructure { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public TaxInformation TaxInformation { get; set; }
    public ICollection<Payroll> Payrolls { get; set; }
    public ICollection<Deduction> Deductions { get; set; }
    public ICollection<Benefit> Benefits { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}