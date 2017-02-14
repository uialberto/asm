using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
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


        }

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new UnitOfWorkInitializer());
            UnitOfWorkTestUtils.RestartUnitOfWork();
            UnitOfWorkTestUtils.GetUnitOfWork().Database.Initialize(true);
        }

    }
}
