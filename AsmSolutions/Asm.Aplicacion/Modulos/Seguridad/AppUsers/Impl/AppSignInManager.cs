using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl
{
    public class AppSignInManager : SignInManager<AppUser, string>
    {
        // ToDo...issue9
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}
