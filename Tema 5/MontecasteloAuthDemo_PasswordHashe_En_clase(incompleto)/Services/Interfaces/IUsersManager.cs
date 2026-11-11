using MontecasteloAuthDemo.Models;
using System.Linq;

namespace MontecasteloAuthDemo.Services.Interfaces
{
    public interface IUsersManager
    {
        bool ExistsByUserName(string userName);
        Usuario? FindByUserName(string userName);
        Usuario? FindById(int id);
        IQueryable<Usuario> Query();
        Usuario Create(string userName, string password, string role);
        void ChangePassword(Usuario user, string newPassword);
        void Update(Usuario user);
        void Delete(Usuario user);
        (bool ok, Usuario? user) VerifyCredentials(string userName, string password);
    }
}
