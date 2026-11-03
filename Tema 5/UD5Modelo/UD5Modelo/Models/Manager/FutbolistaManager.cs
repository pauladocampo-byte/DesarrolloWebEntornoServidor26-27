namespace UD5Modelo.Models.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    namespace UD5Modelo.Services
    {
        public class FutbolistaManager : IFutbolistaManager
        {
            private readonly Ud5Context _context;

            public FutbolistaManager(Ud5Context context)
            {
                _context = context;
            }

            public List<Futbolista> GetAll()
            {
                return _context.Futbolistas
                          .Include(f => f.Equipo)
                          .OrderBy(f => f.Id)
                          .ToList();
            }

            public Futbolista? GetById(int id)
            {
                return _context.Futbolistas
                          .Include(f => f.Equipo)
                          .FirstOrDefault(f => f.Id == id);
            }

            public void Create(Futbolista f)
            {
                _context.Futbolistas.Add(f);
                _context.SaveChanges();
            }

            public void Update(Futbolista f)
            {
                // Opción simple (todas las props): _db.Futbolistas.Update(f);
                // Opción detallada (recomendada si quieres controlar campos):
                var original = _context.Futbolistas.FirstOrDefault(x => x.Id == f.Id);
                if (original is null) return;

                original.Nombre = f.Nombre;
                original.Apellido = f.Apellido;
                original.Dni = f.Dni;
                original.Edad = f.Edad;
                original.Dorsal = f.Dorsal;
                original.MinutosJugados = f.MinutosJugados;
                original.EnActivo = f.EnActivo;
                original.PrecioMercado = f.PrecioMercado;
                original.Telefono = f.Telefono;
                original.EquipoId = f.EquipoId;      // FK (int? o int)
                original.Minutos = f.Minutos;

                _context.SaveChanges();
            }

            public int Delete(int id)
            {
                var entity = _context.Futbolistas.Find(id);
                if (entity is null) return 0;

                _context.Futbolistas.Remove(entity);
                return _context.SaveChanges(); // devuelve filas afectadas
            }

            public List<Equipo> GetEquipos()
            {
                return _context.Equipos
                          .OrderBy(e => e.Nombre)
                          .ToList();
            }

            public bool IsDorsalDisponible(int? dorsal, int? equipoId, int idActual)
            {
                if (dorsal is null || equipoId is null) return true;

                return !_context.Futbolistas.Any(f =>
                    f.Id != idActual &&
                    f.EnActivo &&
                    f.EquipoId == equipoId &&
                    f.Dorsal == dorsal);
            }
        }
    }
}
