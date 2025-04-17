﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Response.Veterinario
{
    public class VeterinarioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int IdEspecialidad { get; set; }

        public string NumeroLicencia { get; set; } = null!;

        public string DocumentoIdentidad { get; set; } = null!;

    }
}
