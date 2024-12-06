using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class ViajesRapidosDto
{
    public int ViajeRapidoId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public int DestinoCercaId { get; set; }
    public string? Destino { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public DateTime Fecha { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public int EstadoVId { get; set; }
    public string? Estado { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public double Precio { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public int personas { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public string? ClienteId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public string? TaxistaId { get; set; }
}
