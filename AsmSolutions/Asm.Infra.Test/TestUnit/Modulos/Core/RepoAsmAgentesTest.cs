using System;
using System.Text;
using System.Collections.Generic;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Infra.Test.Helpers.Modulos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Infra.Test.TestUnit.Modulos.Core
{
    /// <summary>
    /// Summary description for RepoClientesTest
    /// </summary>
    [TestClass]
    public class RepoClientesTest : RepositoriesTest
    {
        [TestMethod]
        public void CrearTest()
        {
            #region Arrange


            var dto = RepoAsmAgentesHelperTest.Get();
            dto.Apellidos = UtilitariosBase.NewGuid();
            dto.Celular = "71100000";

            var res = RepoAsmAgentesHelperTest.Create(dto);

            #endregion

            #region Act

            var target = RepoAsmAgentesHelperTest.CreateRepository();
            var entityAdd = target.Get(dto.Id);

            #endregion

            #region Assert

            Assert.IsNotNull(entityAdd);
            Assert.IsTrue(entityAdd.Id == res.Id,"El identificador no cumple con la logica de la prueba.");

            #endregion

        }
    }
}
