using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Data.Models;

public class ReservacionDetalles
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Reservacion")]
    public int ReservacionId { get; set; }
    public Reservaciones? Reservacion { get; set; }

    [ForeignKey("Articulo")]
    public int ArticuloId { get; set; }
    public Articulos? Articulo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio { get; set; }
}
