using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.ClientesApi;

namespace Asm.Aplicacion.Modulos.Core.ClientesApi.Impl
{
    public class AppServiceClientesApi : IAppServiceClientesApi
    {
        protected readonly IRepoClientesApi Repository;

        #region Constructor

        public AppServiceClientesApi(IRepoClientesApi pRepository)
        {
            if (pRepository == null)
                throw new ArgumentNullException(nameof(pRepository));

            Repository = pRepository;
        }

        #endregion
    }
}
