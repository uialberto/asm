using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
using Asm.Apolo.Core.Result;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Asm.Apolo.Dom.UoW;
using LocalizedText = Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl.Localization.SecurityService;

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

        public ResultElement<long> Register(RegisterAsmDto dto)
        {
            var result = new ResultElement<long>();
            try
            {
                #region Validaciones

                if (string.IsNullOrWhiteSpace(dto?.Nombres))
                {
                    result.Errors.Add(LocalizedText.NombresRequerido);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(dto?.Apellidos))
                {
                    result.Errors.Add(LocalizedText.ApellidosRequerido);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(dto?.Email))
                {
                    result.Errors.Add(LocalizedText.EmailRequerido);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(dto?.Username))
                {
                    result.Errors.Add(LocalizedText.UsernameRequerido);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(dto?.Password))
                {
                    result.Errors.Add(LocalizedText.PasswordRequerido);
                    return result;
                }

                _appUserManager.UserValidator = new UserValidator<AppUser>(_appUserManager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true,

                };
                _appUserManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireDigit = true,
                };


                #endregion

                #region Proceso

                var user = new AppUser()
                {
                    UserName = dto.Username,
                    Email = dto.Email,
                    AsmAgentes = new List<AsmAgente>()
                };

                var agente = new AsmAgente
                {
                    Nombres = dto.Nombres,
                    Apellidos = dto.Apellidos,
                };

                user.AsmAgentes.Add(agente);

                #region Asignacion Rol Public

                var context = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>() as UnitOfWork;

                if (context == null)
                    throw new ArgumentNullException(nameof(context));
                var keyRolPublic = KeyConfiguration.KeyRolPublic;
                var rolPublic = context.Roles.FirstOrDefault(ele => ele.Id.ToLower() == keyRolPublic.ToLower());
                if (rolPublic != null)
                {
                    user.Roles.Add(new IdentityUserRole()
                    {
                        RoleId = rolPublic.Id,
                        UserId = user.Id
                    });
                }

                #endregion

                var res = _appUserManager.Create(user, dto.Password);
                if (!res.Succeeded)
                {
                    // ToDo Personalizar mensajes...
                    //result.Errors.Add(LocalizedText.ErrorRegisterValidations);
                    result.Errors.AddRange(res.Errors);
                }

                result.Element = agente.Id;



                #endregion

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                result.Errors.Add(mensaje);
            }
            return result;
        }

        #endregion

    }
}
