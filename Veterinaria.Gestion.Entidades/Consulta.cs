using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Consulta : EntidadBase
{

    public int IdMascota { get; set; }

    public int IdVeterinario { get; set; }

    public DateTime FechaHora { get; set; }

    public string Motivo { get; set; } = null!;

    public string? Diagnostico { get; set; }

    public string? Medicamento { get; set; }

    public string? Dosis { get; set; }

    public string? Duracion { get; set; }

    public string? Instrucciones { get; set; }

    public string Estado { get; set; } = null!;


    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;
}
