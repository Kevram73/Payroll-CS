namespace Payroll.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public PaymentMethodType Type { get; set; }
    public string BankName { get; set; }
    public string AccountNumber { get; set; }
    public string RoutingNumber { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

public enum PaymentMethodType
{
    BankTransfer,
    DirectDeposit,
    Check,
    Cash
}