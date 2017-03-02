using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using LocalizedText = Asm.Aplicacion.Helpers.Security.Localization.OAuthApiAuthorizationServerProvider;

namespace Asm.Aplicacion.Helpers.Security
{
    public class OAuthApiAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // ToDo...issue9
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // ToDo...issue9

            var userManager = context.OwinContext.GetUserManager<AppUserManager>();

            try
            {
                var user = await userManager.FindAsync(context.UserName, context.Password);
                if (user != null)
                {
                    var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", LocalizedText.InvalidGrant);
                    context.Rejected();
                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                context.SetError("server_error");
                context.Rejected();
            }
        }

    }
}
