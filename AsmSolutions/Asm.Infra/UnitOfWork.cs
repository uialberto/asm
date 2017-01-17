using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Infra.Apolo;
using Asm.Infra.Modulos.Core.Mapping.AsmAgentes;
using Asm.Infra.Modulos.Core.Mapping.Mascotas;

namespace Asm.Infra
{
    public class UnitOfWork : EfUoW
    {
        public UnitOfWork(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new UnitOfWorkInitializer());
            Configuration.LazyLoadingEnabled = false;

        }
        protected UnitOfWork(DbConnection connection) : base(connection)
        {
            Database.SetInitializer(new UnitOfWorkInitializer());
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            builder.Conventions.Remove<PluralizingTableNameConvention>();


            // Modulos Asm
            builder.Configurations.Add(new MascotaConfig());
            builder.Configurations.Add(new AsmAgenteConfig());

        }
    }
}
