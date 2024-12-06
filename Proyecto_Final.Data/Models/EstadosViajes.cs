using System.ComponentModel.DataAnnotations;

namespace ReyAI_Trasport.Data.Models;

public class EstadosViajes
{
    [Key]
    public int EstadosVId { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string? Descripcion { get; set; }
}