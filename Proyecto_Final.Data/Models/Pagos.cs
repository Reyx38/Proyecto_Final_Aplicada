using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Data.Models;

public class Pagos
{
    [Key]
    public int PagoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public double Monto { get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [ForeignKey("Reservacion")]
    public int ReservacionId { get; set; }
    public Reservaciones Reservacion { get; set; }
}
