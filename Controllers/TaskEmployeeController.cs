using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Payroll.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class TaskEmployeeController : Controller
    {
        private readonly ITaskEmployeeRepository _taskRepository;

        public TaskEmployeeController(ITaskEmployeeRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // 🔹 GET: /TaskEmployee
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return View(tasks);
        }

        // 🔹 GET: /TaskEmployee/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // 🔹 GET: /TaskEmployee/Create
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 POST: /TaskEmployee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskEmployee task)
        {
            if (ModelState.IsValid)
            {
                await _taskRepository.AddTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // 🔹 GET: /TaskEmployee/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // 🔹 POST: /TaskEmployee/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskEmployee task)
        {
            if (id != task.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _taskRepository.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // 🔹 GET: /TaskEmployee/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // 🔹 POST: /TaskEmployee/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
