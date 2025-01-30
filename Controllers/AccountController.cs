using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Payroll.Models;
using Payroll.Dto.User;
using Payroll.Data;

namespace Payroll.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PayrollDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, PayrollDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // 🔹 Affiche le formulaire de connexion
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        // 🔹 Gère la connexion de l'utilisateur
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }


            TempData["Success"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }

        // 🔹 Déconnexion de l'utilisateur
        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // 🔹 Supprimer la session et déconnecter l'utilisateur
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();

            TempData["Success"] = "Logout successful!";
            return RedirectToAction("Login");
        }
    }
}
