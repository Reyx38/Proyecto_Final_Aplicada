using ReyAI_Trasport.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [ForeignKey("Estado")]
    public int EstadoId { get; set; }
    public EstadosResrvaciones Estado { get; set; }

	[ForeignKey("ReservacionId")]
    public ICollection<ReservacionDetalles>? ReservacionDetalles { get; set; } = new List<ReservacionDetalles>();
}
