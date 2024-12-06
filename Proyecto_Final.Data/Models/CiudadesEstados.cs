using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Data.Models
{
    public class CiudadesEstados
    {
        [Key]
        public int EstadosCId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Descripcion { get; set; }
    }
}
