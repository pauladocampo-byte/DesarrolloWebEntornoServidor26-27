using CatalogoTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoTienda.Data
{
    public class TiendaContext: DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

         public DbSet<Producto> Productos => Set<Producto>();


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Producto>()
        //        .Property(producto => producto.Precio)
        //        .HasPrecision(10, 2);

        //}
    }
}
