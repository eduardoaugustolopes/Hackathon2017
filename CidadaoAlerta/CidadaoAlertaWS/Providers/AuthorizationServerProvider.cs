using CidadaoAlerta.Application.Application;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace CidadaoAlertaWS.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                var usuario = UsuarioApplication.Get(context.UserName, context.Password);
                if (usuario.Id > 0)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    var claims = new List<string>();
                    
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    Thread.CurrentPrincipal = new GenericPrincipal(identity, claims.ToArray());
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                }
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}