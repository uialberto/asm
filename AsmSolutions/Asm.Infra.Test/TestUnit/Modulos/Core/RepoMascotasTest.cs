using System;
using System.Text;
using System.Collections.Generic;
using Asm.Infra.Test.Helpers.Modulos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Infra.Test.TestUnit.Modulos.Core
{
    /// <summary>
    /// Descripción resumida de RepoMascotasTest
    /// </summary>
    [TestClass]
    public class RepoMascotasTest : RepositoriesTest
    {
        [TestMethod]
        public void CrearTest()
        {
            #region Arrange


            var dto = RepoMascotasHelperTest.Get();
            dto.Nombre = "Homero";
            

            var res = RepoMascotasHelperTest.Create(dto);

            #endregion

            #region Act

            var target = RepoMascotasHelperTest.CreateRepository();
            var entityAdd = target.Get(dto.Id);

            #endregion

            #region Assert

            Assert.IsNotNull(entityAdd);
            Assert.IsTrue(entityAdd.Id == res.Id, "El identificador no cumple con la logica de la prueba.");

            #endregion

        }
    }
}
