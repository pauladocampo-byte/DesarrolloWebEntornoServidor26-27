using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services;
using MontecasteloAuthDemo.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersManager _users;
        public UsersController(IUsersManager users) => _users = users;

        // GET: /Users
        public IActionResult Index(string? q)
        {
            var query = _users.Query();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(u => u.NombreUsuario.Contains(q));
            var list = query.OrderBy(u => u.NombreUsuario).ToList();
            return View(list);
        }

        // GET: /Users/Details/5
        public IActionResult Details(int id)
        {
            var user = _users.FindById(id);
            if (user is null) return NotFound();
            return View(user);
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(Roles.All);
            return View();
        }

        public class CreateUserDto
        {
            [Required, StringLength(40)]
            public string NombreUsuario { get; set; } = default!;

            [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
            public string Password { get; set; } = default!;

            [Required, Compare(nameof(Password)), DataType(DataType.Password)]
            public string ConfirmPassword { get; set; } = default!;

            [Required, StringLength(20)]
            public string Rol { get; set; } = "User";
        }

        // POST: /Users/Create
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (_users.ExistsByUserName(vm.NombreUsuario))
            {
                ModelState.AddModelError(nameof(vm.NombreUsuario), "El usuario ya existe.");
                return View(vm);
            }

            _users.Create(vm.NombreUsuario, vm.Password, vm.Rol);
            TempData["Msg"] = "Usuario creado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _users.FindById(id);
            if (user is null) return NotFound();
            ViewBag.Roles = new SelectList(Roles.All, user.Rol);
            return View(user);
        }

        // POST: /Users/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,NombreUsuario,Rol")] Usuario vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return View(vm);

            var user = _users.FindById(id);
            if (user is null) return NotFound();

            if (!string.Equals(user.NombreUsuario, vm.NombreUsuario, StringComparison.OrdinalIgnoreCase))
            {
                if (_users.ExistsByUserName(vm.NombreUsuario))
                {
                    ModelState.AddModelError(nameof(vm.NombreUsuario), "Ya existe un usuario con ese nombre.");
                    return View(vm);
                }
                user.NombreUsuario = vm.NombreUsuario;
            }
            user.Rol = vm.Rol;

            _users.Update(user);
            TempData["Msg"] = "Usuario actualizado.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Delete/5
        public IActionResult Delete(int id)
        {
            var user = _users.FindById(id);
            if (user is null) return NotFound();
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _users.FindById(id);
            if (user is null) return NotFound();
            _users.Delete(user);
            TempData["Msg"] = "Usuario eliminado.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/ResetPassword/5
        public IActionResult ResetPassword(int id)
        {
            var user = _users.FindById(id);
            if (user is null) return NotFound();
            ViewBag.UserName = user.NombreUsuario;
            return View(new ResetPasswordDto());
        }

        public class ResetPasswordDto
        {
            [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
            public string NewPassword { get; set; } = default!;

            [Required, Compare(nameof(NewPassword)), DataType(DataType.Password)]
            public string ConfirmNewPassword { get; set; } = default!;
        }

        // POST: /Users/ResetPassword/5
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ResetPassword(int id, ResetPasswordDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = _users.FindById(id);
            if (user is null) return NotFound();

            _users.ChangePassword(user, vm.NewPassword);
            TempData["Msg"] = "Contraseña restablecida.";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
