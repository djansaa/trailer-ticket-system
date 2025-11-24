using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrailerTicketSystem.Models;
using TrailerTicketSystem.Repositories;

namespace TrailerTicketSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IPasswordHasher<AppUser> _hasher;

        public AccountController(IAppUserRepository appUserRepository, IPasswordHasher<AppUser> hasher)
        {
            _appUserRepository = appUserRepository;
            _hasher = hasher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login()
        {
            throw new Exception("Not implemented");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
