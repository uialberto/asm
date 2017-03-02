using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
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

        public async Task<int> RegisterAsync(RegisterAsmDto dto)
        {
            var result = -1;
            try
            {
                var userapp = new AppUser()
                {
                    Email = dto.Email,
                    UserName = dto.Username,
                    AsmAgentes = new List<AsmAgente>()
                    {
                        new AsmAgente()
                        {                 
                            Nombres = dto.Nombres,
                            Apellidos = dto.Apellidos
                        }
                    }
                };

                var user = await _appUserManager.CreateAsync(userapp,dto.Password);
                if (user.Errors.Any())
                {
                    // ToDo #issue10
                    return result;
                }
                if (user.Succeeded)
                    result = 1;

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
            return result;
        }
    }
}
