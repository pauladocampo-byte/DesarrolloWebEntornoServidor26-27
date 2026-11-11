using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services.Interfaces;

namespace MontecasteloAuthDemo.Services
{
    public class AuthManager : IAuthManager
    {
        public void SignIn(HttpContext http, Usuario user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Rol)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).GetAwaiter().GetResult();
        }

        public void SignOut(HttpContext http)
        {
            http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).GetAwaiter().GetResult();
        }

        public int? GetCurrentUserId(ClaimsPrincipal user)
        {
            var idClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(idClaim, out var id) ? id : null;
        }
    }
}
