using System;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Asm.Aplicacion.Modulos.Core.AsmAgentes;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Aplicacion.Dtos.DataTransfers;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
using Microsoft.Practices.Unity;

namespace Asm.WebApi.Controllers
{
    public class DemoController : ApiController
    {
        private SecurityService _security;

        protected readonly IAppServiceAsmAgentes AppServiceAsm;

        // ToDo Pendiente inyeccion por constructor...Dependency Resolver
        public DemoController()
        {
            var pAppServiceAsmAgentes = IoCUnityConfiguration.UnityManager.Resolve<IAppServiceAsmAgentes>();

            if (pAppServiceAsmAgentes == null)
                throw new ArgumentNullException(nameof(pAppServiceAsmAgentes));

            _security = new SecurityService(HttpContext.Current.GetOwinContext().Authentication);

            AppServiceAsm = pAppServiceAsmAgentes;

        }
        [Authorize]
        [HttpGet]
        [Route("api/demo/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var asm = AppServiceAsm.Obtener(new AsmAgenteDto() { Id = "10000" });

            return Ok("Hello " + identity.Name);
        }
    }
}
