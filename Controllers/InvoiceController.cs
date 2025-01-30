using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // 🔹 GET: /Invoice
        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();
            return View(invoices);
        }

        // 🔹 GET: /Invoice/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        // 🔹 GET: /Invoice/Create
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 POST: /Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await _invoiceRepository.AddInvoiceAsync(invoice);
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // 🔹 GET: /Invoice/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        // 🔹 POST: /Invoice/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Invoice invoice)
        {
            if (id != invoice.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _invoiceRepository.UpdateInvoiceAsync(invoice);
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // 🔹 GET: /Invoice/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        // 🔹 POST: /Invoice/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _invoiceRepository.DeleteInvoiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
