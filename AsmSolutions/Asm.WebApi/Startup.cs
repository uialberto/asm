using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.WebApi.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Owin;

[assembly: OwinStartup(typeof(Asm.WebApi.Startup))]

namespace Asm.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();

            #region Configuracion ApiVersion

            config.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = new HeaderApiVersionReader(KeyConfiguration.KeyHeaderApiVersion);
            }
           );

            #endregion

            #region Registrar Configuraciones
            //AreaRegistration.RegisterAllAreas();
            #endregion

            WebApiConfig.Register(config);

            IoCUnityInitialize.Initialize();

            AutoMapperConfiguration.Initialize();

            ConfigureOAuth(app);

            TestDataConfiguration.Initialize();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);



        }
    }
}
