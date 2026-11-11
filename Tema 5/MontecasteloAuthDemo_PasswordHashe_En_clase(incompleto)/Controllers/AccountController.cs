using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MontecasteloAuthDemo.Services;
using MontecasteloAuthDemo.ViewModels;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services.Interfaces;

namespace MontecasteloAuthDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager _users;
        private readonly IAuthManager _auth;
        public AccountController(IUsersManager users, IAuthManager auth) { _users = users; _auth = auth; }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm, string? returnUrl = null)
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

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(Roles.All);
            return View(new RegisterViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (_users.ExistsByUserName(vm.UserName))
            {
                ModelState.AddModelError(nameof(vm.UserName), "El usuario ya existe.");
                return View(vm);
            }

            var usuario = _users.Create(vm.UserName, vm.Password, vm.Role);
            _auth.SignIn(HttpContext, usuario);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword() => View(new ChangePasswordViewModel());

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var idOpt = _auth.GetCurrentUserId(User);
            if (idOpt is null) return Forbid();
            int id = idOpt.Value;

            var user = _users.FindById(id);
            if (user is null) return Forbid();

            // validar contraseña actual
            var (ok, _) = _users.VerifyCredentials(user.NombreUsuario, vm.CurrentPassword);
            if (!ok)
            {
                ModelState.AddModelError(nameof(vm.CurrentPassword), "La contraseña actual no es correcta.");
                return View(vm);
            }

            _users.ChangePassword(user, vm.NewPassword);
            TempData["PasswordChanged"] = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _auth.SignOut(HttpContext);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();

        private async Task SignInAsync(Models.Usuario user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Rol)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
