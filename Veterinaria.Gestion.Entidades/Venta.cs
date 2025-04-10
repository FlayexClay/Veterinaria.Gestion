using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class Venta : EntidadBase
{

    public int IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public string MetodoPago { get; set; } = null!;


    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
