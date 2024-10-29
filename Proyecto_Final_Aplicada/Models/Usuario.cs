using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_Aplicada.Models;

public class Usuario
{
    public string NickName { get; set; }

    [Required(ErrorMessage = "Los nombres son requerido.")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]

    public string Nombres { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es requerido.")]

    public DateTime FechaNacimiento { get; set; }
    [Required(ErrorMessage = "El Correo es requerido.")]

    public string Correo {  get; set; }
    [Required(ErrorMessage = "La contraseña es requerido.")]

    public string Password { get; set; }
}
