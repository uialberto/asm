using System;
using Asm.Aplicacion.Helpers;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class SecurityService : ISecurityService
    {
        private AppUserManager _appUserManager;
        private AppSignInManager _appSignInManager; // ToDo por definir...

        public SecurityService()
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));

        }
        public SecurityService(IAuthenticationManager authentication)
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));
            _appSignInManager = new AppSignInManager(_appUserManager, authentication);

        }

    }
}
