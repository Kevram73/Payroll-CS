using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class ProfitController : Controller
    {
        private readonly IProfitRepository _profitRepository;

        public ProfitController(IProfitRepository profitRepository)
        {
            _profitRepository = profitRepository;
        }

        // 🔹 GET: /Profit
        public async Task<IActionResult> Index()
        {
            var profits = await _profitRepository.GetAllProfitsAsync();
            return View(profits);
        }

        // 🔹 GET: /Profit/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var profit = await _profitRepository.GetLatestProfitAsync();
            if (profit == null) return NotFound();
            return View(profit);
        }

        // 🔹 GET: /Profit/Create
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 POST: /Profit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profit profit)
        {
            if (ModelState.IsValid)
            {
                await _profitRepository.AddProfitAsync(profit);
                return RedirectToAction(nameof(Index));
            }
            return View(profit);
        }

        // 🔹 GET: /Profit/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var profit = await _profitRepository.GetLatestProfitAsync();
            if (profit == null) return NotFound();
            return View(profit);
        }

        // 🔹 POST: /Profit/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profit profit)
        {
            if (id != profit.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _profitRepository.UpdateProfitAsync(profit);
                return RedirectToAction(nameof(Index));
            }
            return View(profit);
        }

        // 🔹 GET: /Profit/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var profit = await _profitRepository.GetLatestProfitAsync();
            if (profit == null) return NotFound();
            return View(profit);
        }

        // 🔹 POST: /Profit/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profitRepository.DeleteProfitAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
