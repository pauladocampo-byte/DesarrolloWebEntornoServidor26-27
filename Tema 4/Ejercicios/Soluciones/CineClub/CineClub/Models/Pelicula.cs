using System.ComponentModel.DataAnnotations;
namespace CineClub.Models;

public class Pelicula
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Titulo { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Director { get; set; } = string.Empty;

    [Range(1, 2100)]
    public int AnioEstreno { get; set; }

    [Range(1, 10000)]
    public int DuracionMinutos { get; set; }

    public bool Disponible { get; set; }
}
