using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Asm.Aplicacion.Helpers;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class SecurityService : ISecurityService
    {
        private AppUserManager _appUserManager;
        private AppSignInManager _appSignInManager;

        public SecurityService()
        {
            // Todo... issue9
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));
            _appSignInManager = HttpContext.Current.GetOwinContext().Get<AppSignInManager>();

        }

    }
}
