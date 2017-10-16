

namespace APIServices
{
    using DTO;
    using Infra.Repositories;
    using Microsoft.Owin.Security.OAuth;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public SimpleAuthorizationServerProvider()
        {
            // _usuarioAppService = usuarioAppService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                LoginRepository _rep = new LoginRepository();
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                string user = context.UserName;
                string pwd = context.Password;

                if (!_rep.RegisterUsuario(user, pwd))
                {
                    context.SetError("invalid_grant", "Access denied!");
                    return;
                }
                else
                {
                    usuarioDTO = (UsuarioDTO)_rep.GetUsuario(user, pwd);
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var roles = new List<string>();
                roles.Add(usuarioDTO.PerfilNome);
               
                
                foreach (var item in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, item));

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}