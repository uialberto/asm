
using System.ComponentModel.DataAnnotations;

namespace Asm.Aplicacion.Dtos.ModelView
{
    public class RegisterAsmDto
    {
        [Required(ErrorMessageResourceName = "ErrorNombres", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        [MaxLength(300, ErrorMessageResourceName = "NombresLengthError", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        public string Nombres { get; set; }

        [Required(ErrorMessageResourceName = "ErrorApellidos", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        [MaxLength(300, ErrorMessageResourceName = "ApellidosLengthError", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        public string Apellidos { get; set; }
        [Required(ErrorMessageResourceName = "ErrorUsername", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        public string Username { get; set; }      
        [Required(ErrorMessageResourceName = "ErrorEmail", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        [EmailAddress(ErrorMessageResourceName = "ErrorEmailValid", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "ErrorPassword", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        [DataType(DataType.Password, ErrorMessageResourceName = "ErrorPasswordValid", ErrorMessageResourceType = typeof(Localization.RegisterAsmDto))]
        public string Password { get; set; }
    }
}
