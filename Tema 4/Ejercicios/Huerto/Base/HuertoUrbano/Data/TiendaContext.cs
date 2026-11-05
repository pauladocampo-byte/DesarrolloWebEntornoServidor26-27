using Microsoft.EntityFrameworkCore;

namespace HuertoUrbano.Data;

public class TiendaContext(DbContextOptions<TiendaContext> options) : DbContext(options)
{
}
