using System;

namespace Payroll.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethodId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, Processed, Paid, Cancelled
        public Employee? Employee { get; set; }
    }
}
