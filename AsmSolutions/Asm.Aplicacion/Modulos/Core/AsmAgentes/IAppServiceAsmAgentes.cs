using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.DataTransfers;

namespace Asm.Aplicacion.Modulos.Core.AsmAgentes
{
    public interface IAppServiceAsmAgentes
    {
        int Crear(AsmAgenteDto dto);
        Task<int> CrearAsync(AsmAgenteDto dto);
    }
}
