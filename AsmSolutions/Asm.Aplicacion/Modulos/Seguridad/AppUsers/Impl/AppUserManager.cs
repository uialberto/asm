using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Asm.Aplicacion.Helpers;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class AppUserManager : UserManager<AppUser>
    {
        // ToDo...issue9
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var unitOfWork = IoCUnityConfiguration.UnityManager.Resolve<IUnitOfWork>();

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            var userStore = new UserStore<AppUser>(new UnitOfWork());

            var manager = new AppUserManager(userStore);

            #region Configuracion Validacion User y Password

            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireDigit = true,
            };

            #endregion

            #region Configuracion de Bloqueo de Cuenta Inactiva

            manager.UserLockoutEnabledByDefault = true;
            manager.MaxFailedAccessAttemptsBeforeLockout = 6;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);

            #endregion

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            // Sample https://www.asp.net/identity/overview/features-api/two-factor-authentication-using-sms-and-email-with-aspnet-identity

            return manager;

        }

        public async Task<bool> ExistUserLoginInfo(string provider, string providerKey)
        {
            var result = false;
            var user = await FindAsync(new UserLoginInfo(provider, providerKey));
            if (user != null)
                result = true;
            return result;
        }
    }
}
