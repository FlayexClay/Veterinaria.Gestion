using Blazored.SessionStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.AccesoDatos.Seguridad;
using Veterinaria.Gestion.Presentacion;
using Veterinaria.Gestion.Presentacion.Components;
using Veterinaria.Gestion.Presentacion.Servicios;
using Veterinaria.Gestion.Repositorios.Implementaciones;
using Veterinaria.Gestion.Repositorios.Interfaces;
using Veterinaria.Gestion.Servicio.Implementaciones;
using Veterinaria.Gestion.Servicio.Interfaces;
using Veterinaria.Gestion.Servicio.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<BdVeterinarioContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("bdVeterinario"));
});

builder.Services.AddDbContext<BdSeguridadContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("bdVeterinario"));
});

builder.Services.AddIdentity<SeguridadEntity, IdentityRole>(politica =>
{
    politica.Password.RequireDigit = false;
    politica.Password.RequireUppercase = true;
    politica.Password.RequireLowercase = true;
    politica.Password.RequiredLength = 8;
    politica.Password.RequireNonAlphanumeric = false;
    politica.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BdSeguridadContext>();

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped<AutenticacionService>();

builder.Services.AddScoped<AuthenticationStateProvider>( provider =>
    provider.GetRequiredService<AutenticacionService>());

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie( options => 
{
    options.LoginPath = Rutas.Login;
});

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddScoped<IMascotaRepositorio, MascotaRepositorio>();
builder.Services.AddScoped<IMascotaServicio, MascotaServicio>();

builder.Services.AddAutoMapper(map =>
{
    map.AddProfile<ClienteMap>();
    map.AddProfile<MascotaMap>();
});
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Inicializar(services);
}

app.Run();
