using Asm.WebApi.Models;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asm.WebApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [RoutePrefix("api/mascota")]
    public class MascotaController : ApiController
    {
        protected readonly MascotaModel Model;
        public MascotaController()
        {
            Model = new MascotaModel();
        }

        [AllowAnonymous]
        [Route("olvidadas")]
        [HttpPost]
        public IHttpActionResult Olvidadas()
        {
            #region Proceso

            var result = Model.CantidadMascotasOlvidadas();

            if ((result.HasErrors && result.Data == null) || result.HasErrors)
            {
                var literalize = string.Join(",", result.Errors.ToArray());
                // ToDo Personalizar mensajes de respuesta por http
                var error = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(literalize)
                };
                throw new HttpResponseException(error);
            }
            if (result.Data == null)
            {
                // ToDo Personalizar mensajes de respuesta por http
                return NotFound();
            }
            return Ok(result);

            #endregion
        }


        [AllowAnonymous]
        [Route("salvadas")]
        [HttpPost]
        public IHttpActionResult Salvadas()
        {
            #region Proceso



            var result = Model.CantidadMascotasSalvadas();

            if ((result.HasErrors && result.Data == null) || result.HasErrors)
            {

                var literalize = string.Join(",", result.Errors.ToArray());

                // ToDo Personalizar mensajes de respuesta por http
                var error = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(literalize)
                };
                throw new HttpResponseException(error);
            }
            if (result.Data == null)
            {
                // ToDo Personalizar mensajes de respuesta por http

                return NotFound();
            }
            return Ok(result);

            #endregion
        }

    }
}
