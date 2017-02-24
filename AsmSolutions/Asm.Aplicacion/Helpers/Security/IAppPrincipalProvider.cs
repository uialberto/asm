using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Aplicacion.Helpers.Security
{
    public interface IAppPrincipalProvider
    {
        ClaimsPrincipal GetCurrentUser();
        string GetCurrentUserId();
    }
}
