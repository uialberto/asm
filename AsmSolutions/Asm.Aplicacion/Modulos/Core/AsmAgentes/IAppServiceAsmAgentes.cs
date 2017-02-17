using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.DataTransfers;

namespace Asm.Aplicacion.Modulos.Core.AsmAgentes
{
    public interface IAppServiceAsmAgentes
    {
        AsmAgenteDto Obtener(AsmAgenteDto dto);
        int Crear(AsmAgenteDto dto);

    }
}
