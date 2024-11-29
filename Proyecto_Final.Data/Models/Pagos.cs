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

    [ForeignKey("MetodoPago")]
    public int MetodoPId { get; set; }
    public MetodosPagos metodoPago { get; set; }

    [ForeignKey("Reservacion")]
    public int ReservacionId { get; set; }
    public Reservaciones Reservacion { get; set; }
}
