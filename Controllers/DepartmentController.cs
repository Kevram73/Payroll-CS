using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: /Department/
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }

        // GET: /Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return View(department);
        }

        // GET: /Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.AddDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: /Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return View(department);
        }

        // POST: /Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: /Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
