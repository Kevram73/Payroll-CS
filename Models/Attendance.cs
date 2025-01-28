namespace Payroll.Models;

public class Attendance
{
    public int Id { get; set; }
    public DateTime ClockIn { get; set; }
    public DateTime ClockOut { get; set; }
    public decimal HoursWorked { get; set; }
    public AttendanceStatus Status { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

public enum AttendanceStatus
{
    Present,
    Absent,
    Late,
    Vacation,
    SickLeave
}