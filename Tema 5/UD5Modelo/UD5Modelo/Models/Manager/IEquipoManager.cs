namespace UD5Modelo.Models.Manager
{
    public interface IEquipoManager
    {
        List<Equipo> GetAll();
        Equipo? GetById(int id);
        void Create(Equipo e);
        void Update(Equipo e);
        int Delete(int id);
    }
}
