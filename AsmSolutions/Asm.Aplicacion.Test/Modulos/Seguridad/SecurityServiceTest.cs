using System;
using System.Text;
using System.Collections.Generic;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Infra.Test;
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

        [TestMethod]
        public void RegisterAsyncTest()
        {
            #region Arrange

            var target = CreateAppServices();

            var dtoUser = new RegisterAsmDto()
            {
                Nombres = UtilitariosBase.NewGuid(),
                Apellidos = UtilitariosBase.NewGuid(),
                Username = UtilitariosBase.NewGuid().Substring(0,5),
                Email = UtilitariosBase.NewGuid().Substring(0,5) + "@uibasoft.com",
                Password = UtilitariosBase.NewGuid().Substring(0,8)
            };


            #endregion

            #region Act

            var result = target.Register(dtoUser);

            #endregion

            #region Assert

            Assert.IsTrue(result > 0, "Error: RegisterAsyncTest. Logica no cumple el criterio de Assert");


            #endregion

        }

    }
}
