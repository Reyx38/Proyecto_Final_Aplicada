
using System.ComponentModel.DataAnnotations;

namespace ReyAI_Trasport.Domain.Dto;

public class TaxistaDto
{
    public string TaxistaId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public string? NickName { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public string? Password { get; set; }

	public bool ExisteVehiculo { get; set; }

	public bool ExisteLicencia { get; set; }

	public int EstadoTId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public int? CiudadId { get; set; }
    public string? NombreCiudad { get; set; }

}
