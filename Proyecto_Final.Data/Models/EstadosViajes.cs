using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Data.Models;

public class EstadosViajes
{
    [Key]
    public int EstadosVId { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string? Descripcion { get; set; }
}
