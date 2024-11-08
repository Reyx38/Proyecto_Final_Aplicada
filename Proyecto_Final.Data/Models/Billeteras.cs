using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Data.Models;

public class Billeteras
{
    [Key]
    public int BilleteraId { get; set; }

    [Required]
    public double Saldo { get; set; }

    [ForeignKey("TransaccionId")]
    public ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
