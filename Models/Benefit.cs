namespace Payroll.Models;

public class Benefit
{
    public int Id { get; set; }
    public BenefitType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime BenefitDate { get; set; }
    public string Description { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

public enum BenefitType
{
    Bonus,
    Commission,
    Overtime,
    Allowance,
    Other
}