using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.Entities;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;

namespace Asm.Dominio.Modulos.Core.Agregados.AsmAgentes
{
    public class AsmAgente : Entity<Guid>
    {
        public AsmAgente() : base()
        {

        }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Mascota> Mascotas { get; set; }
    }
}
