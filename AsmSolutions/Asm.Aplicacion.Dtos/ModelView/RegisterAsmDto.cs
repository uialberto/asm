
using System.ComponentModel.DataAnnotations;

namespace Asm.Aplicacion.Dtos.ModelView
{
    public class RegisterAsmDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
