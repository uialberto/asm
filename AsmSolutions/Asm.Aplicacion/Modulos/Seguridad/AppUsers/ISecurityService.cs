using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.ModelView;
using Asm.Apolo.Core.Result;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers
{
    public interface ISecurityService
    {             
        ResultElement<long> Register(RegisterAsmDto dto);
    }
}
