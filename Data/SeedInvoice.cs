using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Models;
using System;

namespace Payroll.Data
{
    public class SeedInvoice : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(
                new Invoice
                {
                    Id = 1,
                    InvoiceNumber = "INV-202401",
                    EmployeeId = 1,
                    Amount = 1500.00m,
                    DueDate = DateTime.UtcNow.AddDays(15),
                    Status = "Pending"
                },
                new Invoice
                {
                    Id = 2,
                    InvoiceNumber = "INV-202402",
                    EmployeeId = 2,
                    Amount = 2000.00m,
                    DueDate = DateTime.UtcNow.AddDays(10),
                    Status = "Paid"
                },
                new Invoice
                {
                    Id = 3,
                    InvoiceNumber = "INV-202403",
                    EmployeeId = 3,
                    Amount = 1800.00m,
                    DueDate = DateTime.UtcNow.AddDays(-5),
                    Status = "Overdue"
                },
                new Invoice
                {
                    Id = 4,
                    InvoiceNumber = "INV-202404",
                    EmployeeId = 4,
                    Amount = 2200.00m,
                    DueDate = DateTime.UtcNow.AddDays(20),
                    Status = "Pending"
                }
            );
        }
    }
}