using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using Asm.Aplicacion.Helpers.Security;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Owin.Security.Providers.GitHub;

namespace Asm.WebApi
{
    public partial class Startup
    {
        public readonly string UrlToken = KeyConfiguration.KeyTokenUrl;

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            #region UseOAuthBearerAuthentication

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //ToDo Modificar en Produccion
                TokenEndpointPath = new PathString(UrlToken),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new OAuthApiAuthorizationServerProvider(),
            };

            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(authOptions);

            #endregion

        }
    }
}