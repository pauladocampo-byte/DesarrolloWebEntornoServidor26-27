using System;
using System.Collections.Generic;

namespace FutbolistaDBFirst.Models;

public partial class Futbolista
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string Apellido { get; set; } = null!;

    public string? Dni { get; set; }

    public int? Edad { get; set; }

    public int? Dorsal { get; set; }

    public int MinutosJugados { get; set; }

    public bool EnActivo { get; set; }

    public decimal? PrecioMercado { get; set; }

    public string Telefono { get; set; } = null!;

    public int? Minutos { get; set; }

    public int? EquipoId { get; set; }

    public virtual Equipo? Equipo { get; set; }
}
