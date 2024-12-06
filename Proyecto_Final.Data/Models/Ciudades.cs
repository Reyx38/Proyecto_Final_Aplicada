using Proyecto_Final.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Data.Models;

public class Ciudades
{
    [Key]
    public int CiudadId { get; set; }

    [Required(ErrorMessage = "Campo requerido.")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string? Nombre { get; set; }
    [ForeignKey("CiudadesEstados")]
    public int EstadoCId { get; set; }
    public CiudadesEstados? CiudadesEstados { get; set; }
}
