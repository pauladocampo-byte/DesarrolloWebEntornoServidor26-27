using Microsoft.AspNetCore.Mvc;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services.Interfaces;

namespace MontecasteloAuthDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager _users;
        private readonly IAuthManager _auth;

        public AccountController(IUsersManager users, IAuthManager auth) 
        { 
            _users = users; 
            _auth = auth; 
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(Models.LoginViewModel vm, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(vm);

            var (ok, user) = _users.VerifyCredentials(vm.UserName, vm.Password);
            if (!ok || user is null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
                return View(vm);
            }

            _auth.SignIn(HttpContext, user);

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
