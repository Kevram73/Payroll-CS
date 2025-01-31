using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Models;
using System;

namespace Payroll.Data
{
    public class SeedAttendance : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasData(
                new Attendance
                {
                    Id = 1,
                    EmployeeId = 1,
                    ClockIn = new DateTime(2024, 1, 15, 9, 0, 0),
                    ClockOut = new DateTime(2024, 1, 15, 17, 0, 0),
                    HoursWorked = 8,
                    Status = AttendanceStatus.Present
                },
                new Attendance
                {
                    Id = 2,
                    EmployeeId = 2,
                    ClockIn = new DateTime(2024, 1, 15, 9, 30, 0),
                    ClockOut = new DateTime(2024, 1, 15, 17, 30, 0),
                    HoursWorked = 8,
                    Status = AttendanceStatus.Late
                },
                new Attendance
                {
                    Id = 3,
                    EmployeeId = 3,
                    ClockIn = new DateTime(2024, 1, 15, 0, 0, 0),
                    ClockOut = new DateTime(2024, 1, 15, 0, 0, 0),
                    HoursWorked = 0,
                    Status = AttendanceStatus.SickLeave
                }
            );
        }
    }
}