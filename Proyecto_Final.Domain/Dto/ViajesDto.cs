using Proyecto_Final.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Domain.Dto;

public class ViajesDto
{
    public int ViajeId { get; set; }

    public string UbicacionInicial { get; set; }

    public string Destino { get; set; }

    public DateTime Fecha { get; set; }

    public TimeOnly Tiempo { get; set; }

    public EstadosViajes Estado { get; set; }

    public int ClienteId { get; set; }

    public int TaxistaId { get; set; }
}
