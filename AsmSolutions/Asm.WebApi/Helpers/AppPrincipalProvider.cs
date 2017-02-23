using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Asm.Aplicacion.Helpers.Security;

namespace Asm.WebApi.Helpers
{

    public class AppPrincipalProvider : IAppPrincipalProvider
    {
        private string _currentUserId = string.Empty;

        public AppPrincipalProvider()
        {
            
        }
        public ClaimsPrincipal GetCurrentUser()
        {
            return ClaimsPrincipal.Current;
        }

        public string GetCurrentUserId()
        {
            if (string.IsNullOrWhiteSpace(_currentUserId) && GetCurrentUser() != null && GetCurrentUser().Claims.Any(c => c.Type == ClaimTypes.NameIdentifier))
            {
                _currentUserId = this.GetCurrentUser().Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }

            return _currentUserId;
        }
    }
}