using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.Entities;

namespace Asm.Dominio.Modulos.Core.Agregados.ClientesApi
{
    public enum TipoClienteApi
    {
        PublicoTestApi = 0,
        ExternalConfidencial = 1
    };
    public class ClienteApi : Entity<long>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ApiCliente { get; set; }
        public string ApiSecret { get; set; }
        public bool Active { get; set; }
        public TipoClienteApi Tipo { get; set; }
        public string PermiteOrigin { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
