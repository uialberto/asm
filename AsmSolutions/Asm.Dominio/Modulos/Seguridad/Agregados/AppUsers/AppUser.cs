using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.Entities;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers
{

    public class AppUser : IdentityUser
    {
        public virtual ICollection<AsmAgente> AsmAgentes { get; set; }
    }
}
