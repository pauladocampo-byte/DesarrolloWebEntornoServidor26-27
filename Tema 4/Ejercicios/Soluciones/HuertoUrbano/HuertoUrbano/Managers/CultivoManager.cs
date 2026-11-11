using HuertoUrbano.Data;
using HuertoUrbano.Models;

namespace HuertoUrbano.Managers;

public class CultivoManager(TiendaContext context)
{
    public List<Cultivo> GetAll() => context.Cultivos.OrderBy(x => x.Nombre).ToList();

    public Cultivo? GetById(int id) => context.Cultivos.Find(id);

    public void Create(Cultivo x)
    {
        context.Cultivos.Add(x);
        context.SaveChanges();
    }

    public void Update(Cultivo x)
    {
        context.Cultivos.Update(x);
        context.SaveChanges();
    }

    public void Delete(Cultivo x)
    {
        context.Cultivos.Remove(x);
        context.SaveChanges();
    }
}
