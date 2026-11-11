using Microsoft.EntityFrameworkCore;
using CineClub.Models;

namespace CineClub.Data;

public class TiendaContext(DbContextOptions<TiendaContext> options) : DbContext(options)
{
    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
}
