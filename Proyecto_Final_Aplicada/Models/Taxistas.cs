using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_Aplicada.Models;

public class Taxistas : Usuario 
{
    [Key]
    public int TaxistaId { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteVehiculo { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteLicencia{ get; set; }

    public Estados Status { get; set; } = Estados.Disponible;

}

public enum Estados
{
    Disponible = 1,
    Ocupado = 2
}
