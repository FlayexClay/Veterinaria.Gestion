using System;
using System.Collections.Generic;

namespace Veterinaria.Gestion.Entidades;

public partial class DetalleVenta : EntidadBase
{

    public int IdVenta { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public int? IdConsulta { get; set; }

    public virtual Consulta? IdConsultaNavigation { get; set; }

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
