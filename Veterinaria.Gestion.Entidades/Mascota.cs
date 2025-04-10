using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Mascota : EntidadBase
{


    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Especie { get; set; } = null!;

    public string? Raza { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? Peso { get; set; }

    public string? Alergias { get; set; }


    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
