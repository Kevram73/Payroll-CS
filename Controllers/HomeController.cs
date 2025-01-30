using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Payroll.Data;
using System.Linq;

namespace Payroll.Controllers
{
    [Authorize] // 🔹 Accès restreint aux utilisateurs connectés
    public class HomeController : Controller
    {
        private readonly PayrollDbContext _context;

        public HomeController(PayrollDbContext context)
        {
            _context = context;
        }

        // 🔹 Dashboard principal
        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.TotalProjects = _context.Projects.Count();
            ViewBag.TotalTasks = _context.TaskEmployees.Count();
            ViewBag.TotalDepartments = _context.Departments.Count();
            ViewBag.TotalDeductions = _context.Deductions.Count();
            ViewBag.TotalBenefits = _context.Benefits.Count();
            ViewBag.TotalInvoices = _context.Invoices.Count();
            ViewBag.TotalPayments = _context.Payments.Count();
            ViewBag.TotalPayrolls = _context.Payrolls.Count();
            ViewBag.TotalSalaryStructures = _context.SalaryStructures.Count();
            ViewBag.TotalTaxInformation = _context.TaxInformations.Count();
            ViewBag.TotalPaymentMethods = _context.PaymentMethods.Count();
            ViewBag.TotalAttendanceRecords = _context.Attendances.Count();
            ViewBag.TotalUsers = _context.Users.Count();
    
            ViewBag.TotalRevenue = _context.Profits.Sum(p => (decimal?)p.TotalRevenue) ?? 0;
            ViewBag.TotalExpenses = _context.Profits.Sum(p => (decimal?)p.TotalExpenses) ?? 0;
            ViewBag.NetProfit = _context.Profits.Sum(p => (decimal?)(p.TotalRevenue - p.TotalExpenses)) ?? 0;

            return View();
        }

    }
}
