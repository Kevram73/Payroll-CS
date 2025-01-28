namespace Payroll.Models;

public class Deduction
{
    public int Id { get; set; }
    public DeductionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime DeductionDate { get; set; }
    public string Description { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

public enum DeductionType
{
    HealthInsurance,
    Retirement,
    Loan,
    Tax,
    Other
}