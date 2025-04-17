namespace Veterinaria.Gestion.Presentacion
{
    public static class Rutas
    {

        public const string Login = "/Login";

        public const string ListaClientes = "/Clientes";
        public const string RegistroClientes = "/Clientes/registro";
        public const string EditarClientesNav = "/Clientes/editar/{id:int}";
        public const string EditarClientes = "/Clientes/editar";

        public const string ListaMascotas = "/Mascotas";
        public const string RegistroMascotas = "/Mascotas/registro";
        public const string EditarMascotasNav = "/Mascotas/editar/{id:int}";
        public const string EditarMascotas = "/Mascotas/editar";

        public const string ListaEspecialidad = "/Especialidad";
        public const string RegistroEspecialidad = "/Especialidad/registro";
        public const string EditarEspecialidadNav = "/Especialidad/editar/{id:int}";
        public const string EditarEspecialidad = "/Especialidad/editar";

        public const string ListaVeterinario = "/Veterinarios";
        public const string RegistroVeterinario = "/Veterinarios/registro";
        public const string EditarVeterinarioNav = "/Veterinarios/editar/{id:int}";
        public const string EditarVeterinario = "/Veterinarios/editar";

    }
}
 