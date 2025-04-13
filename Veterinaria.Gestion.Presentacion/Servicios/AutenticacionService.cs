using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Veterinaria.Gestion.Dto.Response.Login;

namespace Veterinaria.Gestion.Presentacion.Servicios
{
    public class AutenticacionService : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;

        private ClaimsPrincipal _sesionActual = new(new ClaimsIdentity());

        private bool _inicializada = false;

        public AutenticacionService(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_sesionActual));
        }

        public async Task InitializedAsync()
        {
            if (!_inicializada)
            {
                var sesion = await _sessionStorage.GetItemAsync<LoginResponse>("userSession");

                if (sesion != null)
                {
                    var claims = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, sesion.NombreCompleto),
                        new Claim(ClaimTypes.Email, sesion.Email),
                        new Claim(ClaimTypes.Role, sesion.Rol),
                        new Claim(ClaimTypes.NameIdentifier, sesion.Id.ToString())
                    }, "custom");
                    _sesionActual = new(claims);
                    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_sesionActual)));
                    _inicializada = true;
                }
            }
        }

        public async Task Login(LoginResponse sesion)
        {
            var claims = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, sesion.NombreCompleto),
                        new Claim(ClaimTypes.Email, sesion.Email),
                        new Claim(ClaimTypes.Role, sesion.Rol),
                        new Claim(ClaimTypes.NameIdentifier, sesion.Id.ToString())
                    }, "custom");
            _sesionActual = new(claims);
            await _sessionStorage.SetItemAsync("userSession", sesion);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_sesionActual)));
        }


        public async Task Logout()
        {
            _sesionActual = new(new ClaimsIdentity());
            await _sessionStorage.RemoveItemAsync("userSession");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_sesionActual)));
        }

    }
}
