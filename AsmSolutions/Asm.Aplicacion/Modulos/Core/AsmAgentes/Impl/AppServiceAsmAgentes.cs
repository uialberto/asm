using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.DataTransfers;
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

        #endregion

        public int Crear(AsmAgenteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(AsmAgenteDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
