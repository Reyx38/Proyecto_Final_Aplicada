using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class ReservacionDetallesDto
{
    public int DetalleId { get; set; }

    public int ReservacionId { get; set; }

    public int ArticuloId { get; set; }

    public int Cantidad { get; set; }

    public double Precio { get; set; }
    public double Costo { get; set; }
}
