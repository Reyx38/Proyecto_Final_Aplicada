using ReyAI_Trasport.Data;
using ReyAI_Trasport.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Domain.Models;

public class Viajes
{
    [Key]
    public int ViajeId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [ForeignKey("Ciudad")]
    public int Destino { get; set; }
    public Ciudades? Ciudad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime FechaInicio { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	public DateTime FechaCierre { get; set; }

	[ForeignKey("EstadoViaje")]
    public int EstadoVId { get; set; }  
    public EstadosViajes? EstadoViaje { get; set; }

	[Required]
	public string? Descripcion { get; set; }

    [Required]
    public double Precio { get; set; }

    [Required]
    public int personas { get; set; }

    public ICollection<Imagen>? Imagen { get; set; } = new List<Imagen>();

    [ForeignKey("Taxista")]
	public string? TaxistaId { get; set; } 
	public ApplicationUser? Taxista { get; set; }

}
