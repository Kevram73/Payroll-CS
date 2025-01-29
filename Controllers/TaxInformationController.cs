using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class TaxInformationController : Controller
    {
        private readonly ITaxInformationRepository _taxInformationRepository;

        public TaxInformationController(ITaxInformationRepository taxInformationRepository)
        {
            _taxInformationRepository = taxInformationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var taxInfos = await _taxInformationRepository.GetAllAsync();
            return View(taxInfos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var taxInfo = await _taxInformationRepository.GetByIdAsync(id);
            if (taxInfo == null) return NotFound();
            return View(taxInfo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxInformation taxInfo)
        {
            if (ModelState.IsValid)
            {
                await _taxInformationRepository.AddAsync(taxInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(taxInfo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var taxInfo = await _taxInformationRepository.GetByIdAsync(id);
            if (taxInfo == null) return NotFound();
            return View(taxInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaxInformation taxInfo)
        {
            if (id != taxInfo.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _taxInformationRepository.UpdateAsync(taxInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(taxInfo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var taxInfo = await _taxInformationRepository.GetByIdAsync(id);
            if (taxInfo == null) return NotFound();
            return View(taxInfo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taxInformationRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
