using System.ComponentModel.DataAnnotations;
namespace HuertoUrbano.Models;

public class Cultivo
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Variedad { get; set; } = string.Empty;

    [Range(1, 2100)]
    public int FechaSiembra { get; set; }

    [Range(1, 10000)]
    public int SuperficieM2 { get; set; }

    public bool EnProduccion { get; set; }
}
