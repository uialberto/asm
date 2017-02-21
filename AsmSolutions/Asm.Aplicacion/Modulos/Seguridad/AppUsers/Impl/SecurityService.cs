using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Helpers;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class SecurityService : ISecurityService
    {
        // ToDo...issue9
        public SecurityService()
        {
            
        }
    }
}
