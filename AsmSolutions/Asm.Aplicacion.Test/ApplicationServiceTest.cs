using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using Asm.Aplicacion.Helpers;
using Asm.Infra;
using Asm.Infra.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Aplicacion.Test
{
    [TestClass]
    public class ApplicationServiceTest
    {
        [AssemblyInitialize]
        public static void TestAssemblyInitialize(TestContext context)
        {
            AutoMapperConfiguration.Initialize();
            IoCUnityConfiguration.Initialize();

        }

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new UnitOfWorkTestUtilsInitializer());
            UnitOfWorkTestUtils.RestartUnitOfWork();
            UnitOfWorkTestUtils.GetUnitOfWork().Database.Initialize(true);
        }

    }
}
