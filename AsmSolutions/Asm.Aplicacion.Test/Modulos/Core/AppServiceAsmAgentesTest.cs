using System;
using System.Text;
using System.Collections.Generic;
using Asm.Aplicacion.Dtos.DataTransfers;
using Asm.Aplicacion.Modulos.Core.AsmAgentes;
using Asm.Aplicacion.Modulos.Core.AsmAgentes.Impl;
using Asm.Infra.Modulos.Core.Repositorios;
using Asm.Infra.Test;
using Asm.Infra.Test.Helpers.Modulos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Aplicacion.Test.Modulos.Core
{
    /// <summary>
    /// Descripción resumida de ClientesAppServicesTest
    /// </summary>
    [TestClass]
    public class ClientesAppServicesTest : ApplicationServiceTest
    {
        private static IAppServiceAsmAgentes CreateAppServices()
        {
            return new AppServiceAsmAgentes(RepoAsmAgentesHelperTest.CreateRepository())
            {

            };
        }

        [TestMethod]
        public void CrearTest()
        {
            #region Arrange

            var target = CreateAppServices();


            var entity = RepoAsmAgentesHelperTest.Create();

            var dto = new AsmAgenteDto()
            {
                Id = entity.Id
            };

            #endregion

            #region Act

            var result = target.Obtener(dto);

            #endregion

            #region Assert

            Assert.IsTrue(result.Id == entity.Id);
            Assert.IsTrue(result.UserId == entity.UserId);

            #endregion

        }

    }
}
