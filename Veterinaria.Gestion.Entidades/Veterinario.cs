using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Veterinario : EntidadBase
{

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public int IdEspecialidad { get; set; }

    public string NumeroLicencia { get; set; } = null!;

    public string? DocumentoIdentidad { get; set; }


    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;
}
