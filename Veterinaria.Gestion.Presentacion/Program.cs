using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.Presentacion.Components;
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

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddBlazoredToast();

builder.Services.AddAutoMapper(map =>
{
    map.AddProfile<ClienteMap>();
});

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

app.Run();
