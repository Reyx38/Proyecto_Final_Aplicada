using Proyecto_Final.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Data.Models;

public class Taxistas : Usuarios
{
    [Key]
    public int TaxistaId { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteVehiculo { get; set; }

    [Required(ErrorMessage = "Debe llenar este campo.")]
    public bool ExisteLicencia { get; set; }

    public EstadosTaxistas Status { get; set; } = EstadosTaxistas.Disponible;

    [ForeignKey("Billetera")]
    public int BilleteraId { get; set; }
    public Billeteras? Billetera { get; set; }
}
