using System.ComponentModel.DataAnnotations;
using Proyecto_Final.Domain.Enum;

namespace Proyecto_Final.Data.Models
{
    public class Usuarios
    {
        public string NickName { get; set; }

        [Required(ErrorMessage = "Los nombres son requerido.")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Correo es requerido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es requerido.")]
        public string Password { get; set; }

        public Provicias Provicia  { get; set; }

        public Roles Role  { get; set; }
    }
}
