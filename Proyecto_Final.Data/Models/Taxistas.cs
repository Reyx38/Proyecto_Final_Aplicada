using ReyAI_Trasport.Domain.Enum;
using ReyAI_Trasport.Data;
using System.ComponentModel.DataAnnotations;

namespace ReyAI_Trasport.Domain.Models;

public class Taxistas : ApplicationUser
{
    [Key]
	public string Id { get; set; }

	[Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteVehiculo { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteLicencia { get; set; }

    public EstadosTaxistas Status { get; set; } = EstadosTaxistas.Disponible;
}
