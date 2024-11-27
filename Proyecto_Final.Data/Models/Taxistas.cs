using ReyAI_Trasport.Data;
using ReyAI_Trasport.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Domain.Models;

public class Taxistas : ApplicationUser
{
    [Key]
	public string Id { get; set; }

	[Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteVehiculo { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteLicencia { get; set; }

    [ForeignKey("EstadoTaxista")]
    public int EstadoTId { get; set; }
    public EstadosTaxistas? EstadoTaxista { get; set; }
}
