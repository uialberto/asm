using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using Asm.Aplicacion.Helpers.Security;

namespace Asm.WebApi
{
    public partial class Startup
    {
        public readonly string UrlToken = KeyConfiguration.KeyTokenUrl;

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            #region UseOAuthBearerAuthentication

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(UrlToken),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new OAuthApiAuthorizationServerProvider(),
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };

            app.UseOAuthBearerAuthentication(authOptions);

            #endregion

        }
    }
}