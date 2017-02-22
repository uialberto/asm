using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.Apolo.Dtos;

namespace Asm.Aplicacion.Dtos.DataTransfers
{
    public class ClienteApiDto : EntityDto<long>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ApiCliente { get; set; }
        public string ApiSecret { get; set; }
        public bool Active { get; set; }
        public int Tipo { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
