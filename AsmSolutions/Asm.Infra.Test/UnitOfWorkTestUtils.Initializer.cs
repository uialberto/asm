using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Infra.Test
{
    public class UnitOfWorkTestUtilsInitializer : DropCreateDatabaseAlways<UnitOfWork>
    {
        protected override void Seed(UnitOfWork context)
        {
            base.Seed(context);
            //context.CreateSet<TipoOperacion>().Add(new TipoOperacion
            //{
            //    Id = 1,
            //    Nombre = "Neutro",
            //    Descripcion = UtilitariosBase.NewGuid()
            //});
            context.SaveChanges();
        }
    }
}
