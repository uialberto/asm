using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<UnitOfWork>()));

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
    }
}
