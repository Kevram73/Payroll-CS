namespace Payroll.Models;

public class SalaryStructure
{
    public int Id { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal HousingAllowance { get; set; }
    public decimal TransportAllowance { get; set; }
    public decimal MedicalAllowance { get; set; }
    public decimal OtherAllowances { get; set; }
    public DateTime EffectiveDate { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}