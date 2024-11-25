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
    public string Destino { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public EstadosViajes Estado { get; set; } = EstadosViajes.EnCurso;

    [Required]
    public double Precio { get; set; }

    [Required]
    public int personas { get; set; }

    public ICollection<Imagen> Imagenes { get; set; } = new List<Imagen>();

    [ForeignKey("Taxista")]
    public int TaxistaId { get; set; }
    public Taxistas? Taxista { get; set; }

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Clientes? Clientes { get; set; }
}
