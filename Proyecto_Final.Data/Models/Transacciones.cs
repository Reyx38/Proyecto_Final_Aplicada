using Proyecto_Final.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Data.Models;

public class Transacciones
{
    [Key]
    public int TransaccionId { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required]
    public double Monto { get; set; }

    [Required]
    public TipoTransaccion Tipo { get; set; }
}
