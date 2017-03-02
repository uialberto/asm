
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Modulos.Core.AsmAgentes;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Microsoft.Practices.Unity;
using Microsoft.Web.Http;

namespace Asm.WebApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        protected readonly SecurityService Security;
        public AccountController()
        {
            Security = new SecurityService(HttpContext.Current.GetOwinContext().Authentication);
        }
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] RegisterAsmDto param)
        {
            #region Validaciones

            if (param == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Todos los datos son requerido.")
                };
                throw new HttpResponseException(message);
            }

            #endregion

            #region Proceso

            var result = Security.Register(param);

            if ((result <= 0))
            {
                var literalize = "Ha ocurrido error a registrar.";
                var error = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(literalize)
                };
                throw new HttpResponseException(error);
            }

            return Ok(result);

            #endregion
        }
    }
}
