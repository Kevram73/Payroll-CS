namespace Payroll.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public PaymentMethodType Type { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string RoutingNumber { get; set; } = string.Empty;

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}

public enum PaymentMethodType
{
    BankTransfer,
    DirectDeposit,
    Check,
    Cash
}