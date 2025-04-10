using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Cliente : EntidadBase
{

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? DocumentoIdentidad { get; set; }


    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
