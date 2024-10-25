using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_Aplicada.Models
{
    public class Clientes : Usuario
    {
        [Key]
        public int ClienteId { get; set; }
    }
}
