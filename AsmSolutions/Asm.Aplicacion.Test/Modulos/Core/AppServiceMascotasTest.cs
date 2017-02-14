using System;
using System.Text;
using System.Collections.Generic;
using Asm.Aplicacion.Modulos.Core.Mascotas;
using Asm.Aplicacion.Modulos.Core.Mascotas.Impl;
using Asm.Infra.Test.Helpers.Modulos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Aplicacion.Test.Modulos.Core
{
    /// <summary>
    /// Descripción resumida de AppServiceMascotasTest
    /// </summary>
    [TestClass]
    public class AppServiceMascotasTest : ApplicationServiceTest
    {
        private static IAppServiceMascotas CreateAppServices()
        {
            return new AppServiceMascotas(RepoMascotasHelperTest.CreateRepository())
            {

            };
        }

    }
}
