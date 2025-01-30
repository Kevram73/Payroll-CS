using System;

namespace Payroll.Models
{
    public class TaskEmployee
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed
        public DateTime DueDate { get; set; }

    }
}
