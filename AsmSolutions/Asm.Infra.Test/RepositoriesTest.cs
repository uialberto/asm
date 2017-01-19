using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asm.Infra.Test
{
    [TestClass]
    public class RepositoriesTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new UnitOfWorkTestUtilsInitializer());
            UnitOfWorkTestUtils.RestartUnitOfWork();
        }
        public void DetachObject(object obj)
        {
            ((IObjectContextAdapter)UnitOfWorkTestUtils.GetUnitOfWork()).ObjectContext.Detach(obj);
        }
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            if (Database.Exists("AsmInfra"))
                Database.Delete("AsmInfra");
        }
    }
}
