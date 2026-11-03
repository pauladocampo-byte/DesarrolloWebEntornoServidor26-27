using Microsoft.EntityFrameworkCore;

namespace UD5Modelo.Models
{
    public class Ud5Context:DbContext
    {
        public Ud5Context(DbContextOptions<Ud5Context> options) : base(options) { }
        public DbSet<Futbolista> Futbolistas => Set<Futbolista>();
        public DbSet<Equipo> Equipos => Set<Equipo>();   
    }
}
