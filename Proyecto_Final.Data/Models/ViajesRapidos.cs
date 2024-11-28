using ReyAI_Trasport.Data.Models;
using ReyAI_Trasport.Data;
using ReyAI_Trasport.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Data.Models;

public class ViajesRapidos
{
    [Key]
    public int ViajeRapidoId { get; set; }

    [ForeignKey("DestinoCerca")]
    public int DestinoCercaId { get; set; }
    public DestinosCerca? DestinoCerca { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [ForeignKey("EstadoViaje")]
    public int EstadoVId { get; set; }
    public EstadosViajes? EstadoViaje { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se permiten numeros enteros o decimales")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^\d?$", ErrorMessage = "Solo se permiten numeros enteros")]
    public int personas { get; set; }


    [ForeignKey("Taxista")]
    public string? TaxistaId { get; set; }
    public ApplicationUser? Taxista { get; set; }

    [ForeignKey("Cliente")]
    public string? ClienteId { get; set; }
    public ApplicationUser? Cliente { get; set; }
}
