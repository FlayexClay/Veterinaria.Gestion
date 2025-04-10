namespace Veterinaria.Gestion.Presentacion
{
    public static class Rutas
    {
        public const string ListaClientes = "/Clientes";
        public const string RegistroClientes = "/Clientes/registro";
        public const string EditarClientesNav = "/Clientes/editar/{id:int}";
        public const string EditarClientes = "/Clientes/editar";

        public const string ListaMascotas = "/Mascotas";
        public const string RegistroMascotas = "/Mascotas/registro";
        public const string EditarMascotasNav = "/Mascotas/editar/{id:int}";
        public const string EditarMascotas = "/Mascotas/editar";
    }
}
