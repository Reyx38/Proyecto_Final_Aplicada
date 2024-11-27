using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Data.Models;

public class Ciudades
{
    [Key]
    public int CiudadId { get; set; }

    [Required(ErrorMessage = "Campo requerido.")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string? Nombre { get; set; }
}
