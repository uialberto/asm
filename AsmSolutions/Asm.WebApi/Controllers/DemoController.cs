using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;

namespace Asm.WebApi.Controllers
{
    public class DemoController : ApiController
    {
        private SecurityService _security;
        public DemoController()
        {
            _security = new SecurityService(HttpContext.Current.GetOwinContext().Authentication);
        }
        [Authorize]
        [HttpGet]
        [Route("api/demo/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }
    }
}
