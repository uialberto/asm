using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Aplicacion.Helpers
{
    public class KeyConfiguration
    {
        public static string KeyTokenUrl
        {
            get
            {
                var llave = ConfigurationManager.AppSettings["Token.Url"];
                if (string.IsNullOrEmpty(llave))
                    throw new ConfigurationErrorsException("Llave de Web.config: Token.Url");
                return llave;
            }
        }
        public static string KeyRolPublic
        {
            get
            {
                var llave = ConfigurationManager.AppSettings["KeyRolPublic"];
                if (string.IsNullOrEmpty(llave))
                    return "public";
                return llave;
            }
        }
        public static string KeyHeaderApiVersion
        {
            get
            {
                var llave = ConfigurationManager.AppSettings["ApiVersion.Header"];
                if (string.IsNullOrEmpty(llave))
                    throw new ConfigurationErrorsException("Llave de Web.config: ApiVersion.Header");
                return llave;
            }
        }
    }
}
