using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Domain.Dto;

public class BilleteraDto
{
    public int BilleteraId { get; set; }
    public double Saldo { get; set; }
    public List<TransaccionesDto> Transacciones { get; set; } = new List<TransaccionesDto>();
}
