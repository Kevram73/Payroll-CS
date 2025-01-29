using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayrollRepository _payrollRepository;

        public PayrollController(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        // GET: /Payroll/
        public async Task<IActionResult> Index()
        {
            var payrolls = await _payrollRepository.GetAllAsync();
            return View(payrolls);
        }

        // GET: /Payroll/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var payroll = await _payrollRepository.GetByIdAsync(id);
            if (payroll == null) return NotFound();
            return View(payroll);
        }

        // GET: /Payroll/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Payroll/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payroll.Models.Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                await _payrollRepository.AddAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        // GET: /Payroll/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var payroll = await _payrollRepository.GetByIdAsync(id);
            if (payroll == null) return NotFound();
            return View(payroll);
        }

        // POST: /Payroll/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payroll.Models.Payroll payroll)
        {
            if (id != payroll.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _payrollRepository.UpdateAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        // GET: /Payroll/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var payroll = await _payrollRepository.GetByIdAsync(id);
            if (payroll == null) return NotFound();
            return View(payroll);
        }

        // POST: /Payroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _payrollRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
