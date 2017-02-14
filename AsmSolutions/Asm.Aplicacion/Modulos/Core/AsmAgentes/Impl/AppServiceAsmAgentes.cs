using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;

namespace Asm.Aplicacion.Modulos.Core.AsmAgentes.Impl
{
    public class AppServiceAsmAgentes : IAppServiceAsmAgentes
    {
        protected readonly IRepoAsmAgentes Repository;

        #region Constructor

        public AppServiceAsmAgentes(IRepoAsmAgentes pRepository)
        {
            if (pRepository == null)
                throw new ArgumentNullException(nameof(pRepository));

            Repository = pRepository;
        }

        //ToDo Otros constructores...

        #endregion
    }
}
