using HuertoUrbano.Models;

namespace HuertoUrbano.Data;

public static class HuertoUrbanoSeedData
{
    public static void Initialize(TiendaContext context)
    {
        if (context.Cultivos.Any())
        {
            return;
        }

        context.Cultivos.AddRange(
            new Cultivo
            {
                Nombre = "Ejemplo uno",
                Variedad = "Autor/a uno",
                FechaSiembra = 2022,
                SuperficieM2 = 90,
                EnProduccion = true
            },
            new Cultivo
            {
                Nombre = "Ejemplo dos",
                Variedad = "Autor/a dos",
                FechaSiembra = 2024,
                SuperficieM2 = 110,
                EnProduccion = false
            });
        context.SaveChanges();
    }
}
