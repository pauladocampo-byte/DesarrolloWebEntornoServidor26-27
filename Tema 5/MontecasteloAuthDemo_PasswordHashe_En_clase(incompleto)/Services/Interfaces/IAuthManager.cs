using MontecasteloAuthDemo.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MontecasteloAuthDemo.Services.Interfaces
{
    public interface IAuthManager
    {
        void SignIn(HttpContext http, Usuario user);
        void SignOut(HttpContext http);
        int? GetCurrentUserId(ClaimsPrincipal user);
    }
}
