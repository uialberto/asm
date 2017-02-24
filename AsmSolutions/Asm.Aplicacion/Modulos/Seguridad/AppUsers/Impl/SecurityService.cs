using System;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
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
        #region Atributos

        private AppUserManager _appUserManager;
        private AppSignInManager _appSignInManager;
        private IAppPrincipalProvider _principalProvider;
        private IAuthenticationManager _authentication;

        #endregion

        #region Constructor

        public SecurityService()
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;
            var principalProvider = IoCUnityConfiguration.UnityManager.Resolve<IAppPrincipalProvider>();

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            if (principalProvider == null)
                throw new ArgumentNullException(nameof(principalProvider));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));

            _principalProvider = principalProvider;

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

        public SecurityService(IAuthenticationManager authentication, IAppPrincipalProvider principalProvider)
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            if (principalProvider == null)
                throw new ArgumentNullException(nameof(principalProvider));

            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));
            _appSignInManager = new AppSignInManager(_appUserManager, authentication);
            _principalProvider = principalProvider;
            _authentication = authentication;

        }

        #endregion

    }
}
