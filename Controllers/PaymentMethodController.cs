using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        // GET: /PaymentMethod/
        public async Task<IActionResult> Index()
        {
            var paymentMethods = await _paymentMethodRepository.GetAllPaymentMethodsAsync();
            return View(paymentMethods);
        }

        // GET: /PaymentMethod/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null) return NotFound();
            return View(paymentMethod);
        }

        // GET: /PaymentMethod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /PaymentMethod/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethod);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

        // GET: /PaymentMethod/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null) return NotFound();
            return View(paymentMethod);
        }

        // POST: /PaymentMethod/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _paymentMethodRepository.UpdatePaymentMethodAsync(paymentMethod);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

        // GET: /PaymentMethod/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null) return NotFound();
            return View(paymentMethod);
        }

        // POST: /PaymentMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentMethodRepository.DeletePaymentMethodAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
