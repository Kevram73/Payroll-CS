using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class DeductionController : Controller
    {
        private readonly IDeductionRepository _deductionRepository;

        public DeductionController(IDeductionRepository deductionRepository)
        {
            _deductionRepository = deductionRepository;
        }

        // GET: /Deduction/
        public async Task<IActionResult> Index()
        {
            var deductions = await _deductionRepository.GetAllDeductionsAsync();
            return View(deductions);
        }

        // GET: /Deduction/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var deduction = await _deductionRepository.GetDeductionByIdAsync(id);
            if (deduction == null) return NotFound();
            return View(deduction);
        }

        // GET: /Deduction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Deduction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                await _deductionRepository.AddDeductionAsync(deduction);
                return RedirectToAction(nameof(Index));
            }
            return View(deduction);
        }

        // GET: /Deduction/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var deduction = await _deductionRepository.GetDeductionByIdAsync(id);
            if (deduction == null) return NotFound();
            return View(deduction);
        }

        // POST: /Deduction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Deduction deduction)
        {
            if (id != deduction.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _deductionRepository.UpdateDeductionAsync(deduction);
                return RedirectToAction(nameof(Index));
            }
            return View(deduction);
        }

        // GET: /Deduction/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var deduction = await _deductionRepository.GetDeductionByIdAsync(id);
            if (deduction == null) return NotFound();
            return View(deduction);
        }

        // POST: /Deduction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deductionRepository.DeleteDeductionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
