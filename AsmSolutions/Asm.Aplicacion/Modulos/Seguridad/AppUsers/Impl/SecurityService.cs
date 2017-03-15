using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Asm.Apolo.Dom.UoW;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class SecurityService : ISecurityService
    {
        #region Atributos

        private AppUserManager _appUserManager;
        private AppSignInManager _appSignInManager;
        private IAppPrincipalProvider _principalProvider;
        private IAuthenticationManager _authentication;
        private IRepoAsmAgentes _asmAgentes;

        #endregion

        #region Constructor

        public SecurityService()
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;

            var pAsmAgentes = IoCUnityConfiguration.UnityManager.Resolve<IRepoAsmAgentes>();

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            if (pAsmAgentes == null)
                throw new ArgumentNullException(nameof(pAsmAgentes));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));
            _asmAgentes = pAsmAgentes;

        }

        public SecurityService(IAuthenticationManager authentication)
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;
            var pAsmAgentes = IoCUnityConfiguration.UnityManager.Resolve<IRepoAsmAgentes>();

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));

            if (pAsmAgentes == null)
                throw new ArgumentNullException(nameof(pAsmAgentes));

            _appUserManager = new AppUserManager(new UserStore<AppUser>(unitOfWork));
            _appSignInManager = new AppSignInManager(_appUserManager, authentication);
            _asmAgentes = pAsmAgentes;
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

        #region Core

        public long Register(RegisterAsmDto dto)
        {
            long result = -1;
            try
            {
                var entity = new AsmAgente()
                {
                    Nombres = dto.Nombres,
                    Apellidos = dto.Apellidos,
                    User = new AppUser()
                    {
                        UserName = dto.Username,
                        Email = dto.Email,
                        PasswordHash = new PasswordHasher().HashPassword(dto.Password),
                    }
                };

                var unitOfWork = _asmAgentes.UnitOfWork;
                _asmAgentes.Add(entity);
                unitOfWork.SaveChanges();
                result = entity.Id;
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
            return result;
        }

        #endregion

    }
}
