﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Modulos.Core.AsmAgentes;
using Asm.Aplicacion.Modulos.Core.AsmAgentes.Impl;
using Asm.Aplicacion.Modulos.Core.Mascotas;
using Asm.Aplicacion.Modulos.Core.Mascotas.Impl;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
using Asm.Infra;
using Asm.Infra.Modulos.Core.Repositorios;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Helpers
{
    public static class IoCUnityConfiguration
    {
        private static IUnityContainer _unityContainer;
        public static void Initialise()
        {
            Configure();

        }
        private static void Configure()
        {
            ConfigureApp();
            ConfigureUnityBase();
        }
        private static void ConfigureApp()
        {

        }
        private static void ConfigureUnityBase()
        {
            _unityContainer = new UnityContainer();

            #region UnitOfWork

            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Repositorios           

            _unityContainer.RegisterType<IRepoAsmAgentes, RepoAsmAgentes>();
            _unityContainer.RegisterType<IRepoMascotas, RepoMascotas>();


            #endregion

            #region Servicios Aplicacion           

            _unityContainer.RegisterType<ISecurityService, SecurityService>();
            _unityContainer.RegisterType<IAppServiceAsmAgentes, AppServiceAsmAgentes>();
            _unityContainer.RegisterType<IAppServiceMascotas, AppServiceMascotas>();

            #endregion

            #region Componentes Transversales General Applications

            #endregion

        }
        public static IUnityContainer Container => _unityContainer ?? (_unityContainer = new UnityContainer());

    }
}
