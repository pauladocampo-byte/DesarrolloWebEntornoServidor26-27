using Microsoft.AspNetCore.Identity;
using MontecasteloAuthDemo.Data;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MontecasteloAuthDemo.Services
{
    public class UsersManager:IUsersManager
    {
        private readonly AppDbContext _db;
        private readonly IPasswordHasher<Usuario> _hasher;
        public UsersManager(AppDbContext db, IPasswordHasher<Usuario> hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        public void ChangePassword(Usuario user, string newPassword)
        {
            user.PasswordHash = _hasher.HashPassword(user, newPassword);
            _db.SaveChanges();
        }

        public Usuario Create(string userName, string password, string role)
        {
            var user = new Usuario
            {
                NombreUsuario = userName,
                Rol = string.IsNullOrWhiteSpace(role) ? "User" : role
            };
            user.PasswordHash = _hasher.HashPassword(user, password);
            _db.Usuarios.Add(user);
            _db.SaveChanges();
            return user;

        }
        public (bool ok, Usuario? user) VerifyCredentials(string userName, string password)
        {
            var user = FindByUserName(userName);
            if(user is null) 
                return (false, null);
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if(result == PasswordVerificationResult.Failed)
                return (false, null);
            //if(result == PasswordVerificationResult.SuccessRehashNeeded)
            //{
            //    user.PasswordHash = _hasher.HashPassword(user, password);
            //    _db.SaveChanges();
            //}
            return (true, user);
        }

        public void Delete(Usuario user)
        {
           _db.Usuarios.Remove(user);
            _db.SaveChanges();
        }

        public bool ExistsByUserName(string userName)
        {
            return _db.Usuarios.Any(u => u.NombreUsuario == userName);
        }

        public Usuario? FindById(int id)
        {
           return _db.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario? FindByUserName(string userName)
        {
           return _db.Usuarios.FirstOrDefault(u => u.NombreUsuario == userName);
        }

        public void Update(Usuario user)
        {
           _db.Usuarios.Update(user);
           _db.SaveChanges();
        }

        public List<Usuario> GetAll(string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                return _db.Usuarios
                   .Where(u => u.NombreUsuario.Contains(filter))
                   .OrderBy(u => u.NombreUsuario)
                   .ToList();
            }
            else
            {
                return _db.Usuarios
                    .OrderBy(u => u.NombreUsuario)
                    .ToList();
            }
        }
    }
}
