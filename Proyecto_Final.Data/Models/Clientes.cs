using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Data.Models
{
    public class Clientes : Usuarios
    {
        [Key]
        public int ClienteId { get; set; }

        public ICollection<Taxistas> Favoritos { get; set; } = new List<Taxistas>();
    }
}
