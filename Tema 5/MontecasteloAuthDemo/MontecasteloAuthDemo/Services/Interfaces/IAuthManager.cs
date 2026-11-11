using MontecasteloAuthDemo.Models;
using System.Security.Claims;

namespace MontecasteloAuthDemo.Services.Interfaces
{
    public interface IAuthManager
    {
        void SignIn(HttpContext http, Usuario user);
        void SignOut(HttpContext http);
        int? GetCurrentUserId(ClaimsPrincipal user);
    }
}
