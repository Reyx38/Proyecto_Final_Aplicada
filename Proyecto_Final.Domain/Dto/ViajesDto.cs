using System.ComponentModel.DataAnnotations;

namespace ReyAI_Trasport.Domain.Dto;

public class ViajesDto
{
    public int ViajeId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[Range(0.01, int.MaxValue, ErrorMessage = "Debe selecionar un Destino")] 
	public int Destino { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public DateTime Fecha { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[Range(0.01, double.MaxValue, ErrorMessage = "El costo por persona debe ser mayor a 0.")]
	public double Precio { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[Range(0.01, 20, ErrorMessage = "Los viajes deben tener de 1 a 20 personas.")]
	public int personas { get; set; }

	public int EstadoId { get; set; } = 1;

	public List<ImagenDto> Imagenes { get; set; } = new List<ImagenDto>();

	[Required(ErrorMessage = "Debe seleccionar un taxista")]
	public string TaxistaId { get; set; }
}
