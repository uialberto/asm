using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.Apolo.Dtos;

namespace Asm.Aplicacion.Dtos.DataTransfers
{
    public partial class MascotaDto : EntityDto<long>
    {                        
        public MascotaDto() : base()
        {

        }

        [MaxLength(50, ErrorMessageResourceName = "NombreLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(500, ErrorMessageResourceName = "DescripcionLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string Descripcion { get; set; }
        public DateTime? Nacimiento { get; set; }
        public bool? EsMacho { get; set; }

        [MaxLength(30, ErrorMessageResourceName = "RazaLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string Raza { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }

        [MaxLength(20, ErrorMessageResourceName = "KeyColorLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string KeyColor { get; set; }
        [Required]
        [MaxLength(5, ErrorMessageResourceName = "KeyEstadoLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string KeyEstado { get; set; }
        [Required]
        [MaxLength(5, ErrorMessageResourceName = "KeyTipoAnimalLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string KeyTipoAnimal { get; set; }

        [Required]
        [MaxLength(350, ErrorMessageResourceName = "DireccionLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(5, ErrorMessageResourceName = "KeyTamanioLengthError", ErrorMessageResourceType = typeof(Localization.MascotaDto))]
        public string KeyTamanio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string AsmAgenteId { get; set; }
    }
}
