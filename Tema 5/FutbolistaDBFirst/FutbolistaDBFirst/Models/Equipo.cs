using System;
using System.Collections.Generic;

namespace FutbolistaDBFirst.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public int Fundacion { get; set; }

    public virtual ICollection<Futbolista> Futbolista { get; set; } = new List<Futbolista>();
}
