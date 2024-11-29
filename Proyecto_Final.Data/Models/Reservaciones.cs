using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Domain.Dto;
using ReyAI_Trasport.Domain.Models;

namespace ReyAI_Trasport.Data.Models;

public class Reservaciones
{
    [Key]
    public int ReservacionId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [ForeignKey("Viaje")]
    public int ViajeId { get; set; }
    public Viajes? Viaje { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public bool Pago { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string? Recibo { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public double Monto { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
    public int CantidadPasajeros { get; set; }

	[ForeignKey("ReservacionId")]
    public ICollection<ReservacionDetalles>? ReservacionDetalles { get; set; } = new List<ReservacionDetalles>();
}
