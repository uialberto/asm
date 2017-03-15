
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
using Asm.WebApi.Controllers.Localization;
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
                    Content = new StringContent(LocalizedText.AllRequeridos)
                };
                throw new HttpResponseException(message);
            }

            #endregion

            #region Proceso

            var result = Security.Register(param);

            if ((result.HasErrors))
            {
                var literalizeErrors = string.Join(",", result.Errors.ToArray());
                var error = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(literalizeErrors)
                };
                throw new HttpResponseException(error);
            }

            return Ok(new
            {
                Data = new
                {
                    Codigo = result.Element
                }
            });

            #endregion
        }
    }
}
