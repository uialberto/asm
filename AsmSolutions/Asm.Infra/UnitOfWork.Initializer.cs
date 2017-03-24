using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Infra
{
    public class UnitOfWorkInitializer : DropCreateDatabaseIfModelChanges<UnitOfWork>
    {
        protected override void Seed(UnitOfWork context)
        {
            base.Seed(context);
            context.SaveChanges();


        }


    }
}
