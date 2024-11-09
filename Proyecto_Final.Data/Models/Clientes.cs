using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Data.Models;

public class Clientes : Usuarios
{
    [Key]
    public int ClienteId { get; set; }

    public ICollection<Taxistas> Favoritos { get; set; } = new List<Taxistas>();

    [ForeignKey("Billetera")]
    public int BilleteraId { get; set; }
    public Billeteras? Billetera { get; set; }
}
