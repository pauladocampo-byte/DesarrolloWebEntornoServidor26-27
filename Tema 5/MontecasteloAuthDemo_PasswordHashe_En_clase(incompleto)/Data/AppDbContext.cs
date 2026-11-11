using Microsoft.EntityFrameworkCore;
using MontecasteloAuthDemo.Models;

namespace MontecasteloAuthDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuarios");
                e.HasIndex(u => u.NombreUsuario).IsUnique();
                e.Property(p => p.NombreUsuario).HasMaxLength(40);
                e.Property(p => p.PasswordHash).HasMaxLength(256);
                e.Property(p => p.Rol).HasMaxLength(20);
            });

        }
    }
}
