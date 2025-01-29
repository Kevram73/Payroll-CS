using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class SalaryStructureController : Controller
    {
        private readonly ISalaryStructureRepository _salaryStructureRepository;

        public SalaryStructureController(ISalaryStructureRepository salaryStructureRepository)
        {
            _salaryStructureRepository = salaryStructureRepository;
        }

        // GET: /SalaryStructure/
        public async Task<IActionResult> Index()
        {
            var salaryStructures = await _salaryStructureRepository.GetAllAsync();
            return View(salaryStructures);
        }

        // GET: /SalaryStructure/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var salaryStructure = await _salaryStructureRepository.GetByIdAsync(id);
            if (salaryStructure == null) return NotFound();
            return View(salaryStructure);
        }

        // GET: /SalaryStructure/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /SalaryStructure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryStructure salaryStructure)
        {
            if (ModelState.IsValid)
            {
                await _salaryStructureRepository.AddAsync(salaryStructure);
                return RedirectToAction(nameof(Index));
            }
            return View(salaryStructure);
        }

        // GET: /SalaryStructure/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var salaryStructure = await _salaryStructureRepository.GetByIdAsync(id);
            if (salaryStructure == null) return NotFound();
            return View(salaryStructure);
        }

        // POST: /SalaryStructure/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalaryStructure salaryStructure)
        {
            if (id != salaryStructure.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _salaryStructureRepository.UpdateAsync(salaryStructure);
                return RedirectToAction(nameof(Index));
            }
            return View(salaryStructure);
        }

        // GET: /SalaryStructure/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var salaryStructure = await _salaryStructureRepository.GetByIdAsync(id);
            if (salaryStructure == null) return NotFound();
            return View(salaryStructure);
        }

        // POST: /SalaryStructure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _salaryStructureRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
