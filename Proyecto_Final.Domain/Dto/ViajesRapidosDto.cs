using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class ViajesRapidosDto
{
    public int ViajeRapidoId { get; set; }

    public int DestinoCercaId { get; set; }

    public DateTime Fecha { get; set; }

    public int EstadoVId { get; set; }

    public double Precio { get; set; }

    public int personas { get; set; }

    public string? ClienteId { get; set; }

    public string? TaxistaId { get; set; }
}
