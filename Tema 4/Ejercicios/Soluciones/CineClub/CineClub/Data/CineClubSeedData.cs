using CineClub.Models;

namespace CineClub.Data;

public static class CineClubSeedData
{
    public static void Initialize(TiendaContext context)
    {
        if (context.Peliculas.Any())
        {
            return;
        }

        context.Peliculas.AddRange(
            new Pelicula
            {
                Titulo = "Ejemplo uno",
                Director = "Autor/a uno",
                AnioEstreno = 2022,
                DuracionMinutos = 90,
                Disponible = true
            },
            new Pelicula
            {
                Titulo = "Ejemplo dos",
                Director = "Autor/a dos",
                AnioEstreno = 2024,
                DuracionMinutos = 110,
                Disponible = false
            });
        context.SaveChanges();
    }
}
