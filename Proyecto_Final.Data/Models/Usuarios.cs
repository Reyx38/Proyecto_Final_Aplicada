using System.ComponentModel.DataAnnotations;
using Proyecto_Final.Domain.Enum;

namespace Proyecto_Final.Data.Models;

public class Usuarios
{
    [Required(ErrorMessage = "Los nombres son requerido.")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
		public string? NickName { get; set; }

		[Required(ErrorMessage = "La fecha de nacimiento es requerido.")]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El Correo es requerido.")]
    public string Correo { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida.")]
    public string Password { get; set; }

    public Provincias? Provicia  { get; set; }

    public Roles Role  { get; set; }
}
