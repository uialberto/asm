using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.Apolo.Dtos;

namespace Asm.Aplicacion.Dtos.DataTransfers
{
    public partial class AsmAgenteDto : EntityDto<string>
    {
        public AsmAgenteDto() : base()
        {

        }
        [Required]
        [MaxLength(300, ErrorMessageResourceName = "NombresLengthError", ErrorMessageResourceType = typeof(Localization.AsmAgenteDto))]

        public string Nombres { get; set; }

        [MaxLength(300, ErrorMessageResourceName = "ApellidosLengthError", ErrorMessageResourceType = typeof(Localization.AsmAgenteDto))]
        public string Apellidos { get; set; }
        [MaxLength(20, ErrorMessageResourceName = "CelularLengthError", ErrorMessageResourceType = typeof(Localization.AsmAgenteDto))]
        public string Celular { get; set; }
        [MaxLength(20, ErrorMessageResourceName = "TelefonoLengthError", ErrorMessageResourceType = typeof(Localization.AsmAgenteDto))]
        public string Telefono { get; set; }
        [MaxLength(500, ErrorMessageResourceName = "DireccionLengthError", ErrorMessageResourceType = typeof(Localization.AsmAgenteDto))]
        public string Direccion { get; set; }
        public virtual ICollection<MascotaDto> Mascotas { get; set; }
        public string UserId { get; set; }
    }
}
