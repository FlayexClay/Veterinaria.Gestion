using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Especialidad : EntidadBase
{

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }


    public virtual ICollection<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();
}
