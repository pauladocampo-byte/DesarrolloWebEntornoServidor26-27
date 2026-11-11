
using Microsoft.EntityFrameworkCore;
using MontecasteloAuthDemo.Models;

namespace MontecasteloAuthDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios=> Set<Usuario>();
    }
}
