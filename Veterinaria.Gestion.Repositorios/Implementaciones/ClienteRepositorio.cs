using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;

namespace Veterinaria.Gestion.Repositorios.Implementaciones
{
    public class ClienteRepositorio(BdVeterinarioContext contexto) : RepositorioBase<Cliente>(contexto), IClienteRepositorio
    {

    }
}
