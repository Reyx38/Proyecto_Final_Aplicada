using ReyAI_Trasport.Data;
using ReyAI_Trasport.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Domain.Models;

public class Viajes
{
    [Key]
    public int ViajeId { get; set; }

    [ForeignKey("Ciudad")]
    public int CiudadId { get; set; }
    public Ciudades? Ciudad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [ForeignKey("EstadoViaje")]
    public int EstadoVId { get; set; }  
    public EstadosViajes? EstadoViaje { get; set; }

    [Required]
    public double Precio { get; set; }

    [Required]
    public int personas { get; set; }

    public ICollection<Imagen> Imagen { get; set; } = new List<Imagen>();

    [ForeignKey("Taxista")]
	public string? TaxistaId { get; set; } 
	public ApplicationUser? Taxista { get; set; }

	[ForeignKey("Cliente")]
    public string? ClienteId { get; set; }
    public ApplicationUser? Cliente { get; set; }
}
