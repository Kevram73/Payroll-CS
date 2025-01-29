using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class BenefitController : Controller
    {
        private readonly IBenefitRepository _benefitRepository;

        public BenefitController(IBenefitRepository benefitRepository)
        {
            _benefitRepository = benefitRepository;
        }

        // GET: /Benefit/
        public async Task<IActionResult> Index()
        {
            var benefits = await _benefitRepository.GetAllBenefitsAsync();
            return View(benefits);
        }

        // GET: /Benefit/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var benefit = await _benefitRepository.GetBenefitByIdAsync(id);
            if (benefit == null) return NotFound();
            return View(benefit);
        }

        // GET: /Benefit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Benefit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                await _benefitRepository.AddBenefitAsync(benefit);
                return RedirectToAction(nameof(Index));
            }
            return View(benefit);
        }

        // GET: /Benefit/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var benefit = await _benefitRepository.GetBenefitByIdAsync(id);
            if (benefit == null) return NotFound();
            return View(benefit);
        }

        // POST: /Benefit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Benefit benefit)
        {
            if (id != benefit.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _benefitRepository.UpdateBenefitAsync(benefit);
                return RedirectToAction(nameof(Index));
            }
            return View(benefit);
        }

        // GET: /Benefit/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var benefit = await _benefitRepository.GetBenefitByIdAsync(id);
            if (benefit == null) return NotFound();
            return View(benefit);
        }

        // POST: /Benefit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _benefitRepository.DeleteBenefitAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
