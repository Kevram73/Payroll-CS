using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // 🔹 GET: /Payment
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return View(payments);
        }

        // 🔹 GET: /Payment/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }

        // 🔹 GET: /Payment/Create
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 POST: /Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                await _paymentRepository.AddPaymentAsync(payment);
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // 🔹 GET: /Payment/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }

        // 🔹 POST: /Payment/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payment payment)
        {
            if (id != payment.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _paymentRepository.UpdatePaymentAsync(payment);
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // 🔹 GET: /Payment/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }

        // 🔹 POST: /Payment/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
