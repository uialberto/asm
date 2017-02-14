using System;
using System.Text;
using System.Collections.Generic;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Infra.Test.Helpers.Modulos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Aplicacion.Test.Modulos.Seguridad
{
    /// <summary>
    /// Descripción resumida de SecurityServiceTest
    /// </summary>
    [TestClass]
    public class SecurityServiceTest : ApplicationServiceTest
    {
        private static ISecurityService CreateAppServices()
        {
            return new SecurityService()
            {

            };
        }

    }
}
