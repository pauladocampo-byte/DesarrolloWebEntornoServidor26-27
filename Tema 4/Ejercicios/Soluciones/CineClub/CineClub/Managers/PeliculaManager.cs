using CineClub.Data;
using CineClub.Models;

namespace CineClub.Managers;

public class PeliculaManager(TiendaContext context)
{
    public List<Pelicula> GetAll() => context.Peliculas.OrderBy(x => x.Titulo).ToList();

    public Pelicula? GetById(int id) => context.Peliculas.Find(id);

    public void Create(Pelicula x)
    {
        context.Peliculas.Add(x);
        context.SaveChanges();
    }

    public void Update(Pelicula x)
    {
        context.Peliculas.Update(x);
        context.SaveChanges();
    }

    public void Delete(Pelicula x)
    {
        context.Peliculas.Remove(x);
        context.SaveChanges();
    }
}
