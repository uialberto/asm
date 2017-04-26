using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Apolo.Services;
using Asm.Aplicacion.Dtos.DataTransfers;
using Asm.Apolo.Core.Result;

namespace Asm.Aplicacion.Modulos.Core.Mascotas
{
    public interface IAppServiceMascotas
    {
        ResultList<MascotaDto> MascotasOlvidadas();
        ResultElement<long> CantidadMascotasOlvidadas();        
    }
}
