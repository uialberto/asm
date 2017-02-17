using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Asm.Aplicacion.Dtos.DataTransfers.Localization;
using Asm.Aplicacion.Modulos.Core.Mascotas;
using Asm.Aplicacion.Modulos.Core.Mascotas.Impl;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
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
        [TestMethod]
        public void MascotasOlvidadasTest()
        {
            #region Arrange

            var target = CreateAppServices();

            for (int i = 1; i <= 10; i++)
            {
                var entity = RepoMascotasHelperTest.Create();
            }


            #endregion

            #region Act

            var result = target.MascotasOlvidadas();

            #endregion

            #region Assert
            Assert.IsTrue(result.Count == 10);
            Assert.IsTrue(result.ToList().All(ele => ele.KeyEstado.ToUpper() == Mascota.KeyEstadoPendiente),
                "La prueba MascotasOlvidadas no cumple el criterio de seleccion.");

            #endregion

        }

    }
}
