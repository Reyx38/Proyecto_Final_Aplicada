using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Domain.Models;

public class Imagen
{
	[Key]
	public int ImagenId { get; set; }
    public string ImagenUrl { get; set; }
    public string Alt { get; set; }
    public string Titulo { get; set; }
    public string? Base64 { get; set; }
    public int ViajeId { get; set; }
	[ForeignKey("ViajeId")]
    public Viajes? Viaje { get; set; }
}
