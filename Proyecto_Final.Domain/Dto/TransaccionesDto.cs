using Proyecto_Final.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Domain.Dto;

public class TransaccionesDto
{
    public int TransaccionId { get; set; }
    public DateTime Fecha { get; set; }
    public double Monto { get; set; }
    public TipoTransaccion Tipo { get; set; }
}
