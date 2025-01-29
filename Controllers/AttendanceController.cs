using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Interfaces;
using Payroll.Models;
using Payroll.Repositories;

namespace Payroll.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        // GET: /Attendance/
        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceRepository.GetAllAttendancesAsync();
            return View(attendances);
        }

        // GET: /Attendance/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if (attendance == null) return NotFound();
            return View(attendance);
        }

        // GET: /Attendance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                await _attendanceRepository.AddAttendanceAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: /Attendance/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if (attendance == null) return NotFound();
            return View(attendance);
        }

        // POST: /Attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Attendance attendance)
        {
            if (id != attendance.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _attendanceRepository.UpdateAttendanceAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: /Attendance/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if (attendance == null) return NotFound();
            return View(attendance);
        }

        // POST: /Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceRepository.DeleteAttendanceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
