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
using Asm.Infra.Test;

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
            Assert.IsTrue(result.TotalElements == 10);
            Assert.IsTrue(result.Elements.ToList().All(ele => ele.KeyEstado.ToUpper() == Mascota.KeyEstadoPendiente),
                "La prueba MascotasOlvidadas no cumple el criterio de seleccion.");

            #endregion

        }

        [TestMethod]
        public void CantidadMascotasOlvidadasTest()
        {
            #region Arrange

            var target = CreateAppServices();

            for (int i = 1; i <= 10; i++)
            {
                Mascota entity = null;
                if ((i % 10) == 0)
                {
                    entity = RepoMascotasHelperTest.Get();
                    entity.KeyEstado = "P";
                }
                else
                {
                    entity = RepoMascotasHelperTest.Get();
                    entity.KeyEstado = "C";
                }

                var res = RepoMascotasHelperTest.Create(entity);

            }


            #endregion

            #region Act

            var result = target.CantidadMascotasOlvidadas();

            #endregion

            #region Assert
            Assert.IsTrue(result.Element > 0);

            Assert.IsTrue(result.Element == 5, "La prueba CantidadMascotasOlvidadasTest no cumple el criterio de seleccion.");


            #endregion

        }

        [TestMethod]
        public void CantidadMascotasSalvadasTest()
        {
            #region Arrange

            var target = CreateAppServices();

            for (int i = 1; i <= 10; i++)
            {
                Mascota entity = null;
                if ((i % 10) == 0)
                {
                    entity = RepoMascotasHelperTest.Get();
                    entity.KeyEstado = "P";
                }
                else
                {
                    entity = RepoMascotasHelperTest.Get();
                    entity.KeyEstado = "A";
                }

                var res = RepoMascotasHelperTest.Create(entity);

            }


            #endregion

            #region Act

            var result = target.CantidadMascotasSalvadas();

            #endregion

            #region Assert
            Assert.IsTrue(result.Element > 0);

            Assert.IsTrue(result.Element == 5, "La prueba CantidadMascotasSalvadasTest no cumple el criterio de seleccion.");


            #endregion

        }

    }
}
