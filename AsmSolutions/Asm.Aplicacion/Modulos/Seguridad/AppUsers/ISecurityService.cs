using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.ModelView;

namespace Asm.Aplicacion.Modulos.Seguridad.AppUsers
{
    public interface ISecurityService
    {        
        Task<int> RegisterAsync(RegisterAsmDto dto);
    }
}
