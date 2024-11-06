using Proyecto_Final.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Domain.Dto
{
    public class ClientesDto
    {
        public int ClienteId { get; set; }

        public string NickName { get; set; }

        [Required(ErrorMessage = "Los nombres son requerido.")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo es requerido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; }

        public ICollection<TaxistaDto> Favoritos { get; set; } = new List<TaxistaDto>();
    }
}
