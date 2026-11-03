namespace UD5Modelo.Models.Manager
{
    public interface IFutbolistaManager
    {
        List<Futbolista> GetAll();
        Futbolista? GetById(int id);
        void Create(Futbolista f);
        void Update(Futbolista f);
        int Delete(int id);

        List<Equipo> GetEquipos();

        /// <summary>
        /// Comprueba si un dorsal está libre en un equipo, excluyendo al futbolista con idActual.
        /// </summary>
        bool IsDorsalDisponible(int? dorsal, int? equipoId, int idActual);
    }
}