namespace Payroll.Models;

public class TaxInformation
{
    public int Id { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public TaxFilingStatus FilingStatus { get; set; }
    public decimal TaxWithholding { get; set; }
    public decimal Exemptions { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

public enum TaxFilingStatus
{
    Single,
    MarriedFilingJointly,
    MarriedFilingSeparately,
    HeadOfHousehold
}

