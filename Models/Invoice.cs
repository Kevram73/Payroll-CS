using System;

namespace Payroll.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Pending"; // Paid, Pending, Overdue
    }
}
