using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Helpers.Security;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Microsoft.Practices.Unity;

namespace Asm.WebApi.Helpers
{
    public static class IoCUnityInitialize
    {
        public static void Initialize()
        {
            Configure();

        }
        private static void Configure()
        {
            #region Registro de Componentes Transversales

            var unityContainer = IoCUnityConfiguration.UnityManager;

            //unityContainer.RegisterType<IAppPrincipalProvider, AppPrincipalProvider>();
            //unityContainer.RegisterType<ISecurityService, SecurityService>();

            #endregion

            IoCUnityConfiguration.Initialize();
        }
    }
}