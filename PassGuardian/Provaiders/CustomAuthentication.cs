using Microsoft.AspNetCore.Components.Authorization;
using PassGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PassGuardian.Provaiders
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }

        public void Authenticate(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
            }, "apiauth_type");
        }

        public void CerrarSesion()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        /*public async Task CloseSession()
        {
           NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }*/
    }
}
