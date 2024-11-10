using Proyecto_Final.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Data.Models;

public class Viajes
{
    [Key]
    public int ViajeId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string UbicacionInicial { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Destino { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public TimeSpan Tiempo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public EstadosViajes Estado { get; set; } = EstadosViajes.Pendiente;

    [Required]
    public double Precio { get; set; }

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Clientes? Cliente { get; set; }

    [ForeignKey("Taxista")]
    public int TaxistaId { get; set; }
    public Taxistas? Taxista { get; set; }
}
