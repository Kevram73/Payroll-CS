namespace Payroll.Models;

public class Payroll
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPeriodEnd { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime PaymentDate { get; set; }
    public PayrollStatus Status { get; set; }

    public Employee? Employee { get; set; }
}

public enum PayrollStatus
{
    Pending,
    Processed,
    Paid,
    Cancelled
}