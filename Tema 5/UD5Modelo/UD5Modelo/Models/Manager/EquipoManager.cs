using Microsoft.EntityFrameworkCore;
using UD5Modelo.Models;
using UD5Modelo.Models.Manager;

namespace UD5Modelo.Services
{
    public class EquipoManager : IEquipoManager
    {
        private readonly Ud5Context _context;

        public EquipoManager(Ud5Context context)
        {
            _context = context;
        }

        public List<Equipo> GetAll()
        {
            // Si quieres listado con sus futbolistas, añade .Include(e => e.Futbolistas)
            return _context.Equipos
                      .OrderBy(e => e.Nombre)
                      .ToList();
        }

        public Equipo? GetById(int id)
        {
            return _context.Equipos
                      .Include(e => e.Futbolistas) // opcional
                      .FirstOrDefault(e => e.Id == id);
        }

        public void Create(Equipo e)
        {
            _context.Equipos.Add(e);
            _context.SaveChanges();
        }

        public void Update(Equipo e)
        {
            var original = _context.Equipos.FirstOrDefault(x => x.Id == e.Id);
            if (original is null) return;

            original.Nombre = e.Nombre;
            // actualiza otras propiedades si las tienes

            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _context.Equipos.Find(id);
            if (entity is null) return 0;

            _context.Equipos.Remove(entity);
            return _context.SaveChanges(); // devuelve filas afectadas
        }
    }
}
