using Microsoft.EntityFrameworkCore;
using HuertoUrbano.Models;

namespace HuertoUrbano.Data;

public class TiendaContext(DbContextOptions<TiendaContext> options) : DbContext(options)
{
    public DbSet<Cultivo> Cultivos => Set<Cultivo>();
}
