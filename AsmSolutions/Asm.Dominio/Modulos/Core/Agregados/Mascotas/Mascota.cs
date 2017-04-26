using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.Entities;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;

namespace Asm.Dominio.Modulos.Core.Agregados.Mascotas
{
    public partial class Mascota : Entity<long>
    {
        public const string KeyEstadoCreado = "C";
        public const string KeyEstadoPendiente = "P";
        public const string KeyEstadoAdptado = "A";

        public Mascota() : base()
        {

        }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Nacimiento { get; set; }
        public bool? EsMacho { get; set; }
        public string Raza { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
        public string KeyColor { get; set; }
        public string KeyEstado { get; set; }
        public string KeyTipoAnimal { get; set; }
        public string Direccion { get; set; }
        public string KeyTamanio { get; set; }
        public DateTime FechaCreacion { get; set; }


        public long AsmAgenteId { get; set; }
        public virtual AsmAgente AsmAgente { get; set; }




    }
}
