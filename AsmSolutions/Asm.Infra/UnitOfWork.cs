using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra.Apolo;
using Asm.Infra.Modulos.Core.Mapping.AsmAgentes;
using Asm.Infra.Modulos.Core.Mapping.Mascotas;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Asm.Infra
{
    public class UnitOfWork : EfUoWIdentity
    {
        #region Constructor

        public UnitOfWork()
            : base("AsmContext")
        {

        }

        public UnitOfWork(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new UnitOfWorkInitializer());
            Configuration.LazyLoadingEnabled = false;
        }
        protected UnitOfWork(DbConnection connection)
            : base(connection)
        {
            Database.SetInitializer(new UnitOfWorkInitializer());
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region Configuracion

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Custom table names for ASP.NET Identity
            //http://coderdiaries.com/2014/01/29/custom-table-names-for-asp-net-identity/


            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            builder.Conventions.Remove<PluralizingTableNameConvention>();


            // Modulos Asm
            builder.Configurations.Add(new MascotaConfig());
            builder.Configurations.Add(new AsmAgenteConfig());

        }

        #endregion

    }
}
