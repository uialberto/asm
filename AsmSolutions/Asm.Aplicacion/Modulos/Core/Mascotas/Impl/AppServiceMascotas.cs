using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Apolo.Services;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;

namespace Asm.Aplicacion.Modulos.Core.Mascotas.Impl
{
    public class AppServiceMascotas : IAppServiceMascotas
    {
        protected readonly IRepoMascotas Repository;

        #region Constructor

        public AppServiceMascotas(IRepoMascotas pRepository)
        {
            if (pRepository == null)
                throw new ArgumentNullException(nameof(pRepository));

            Repository = pRepository;
        }

        //ToDo Otros constructores...

        #endregion

    }
}
