using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class ArticulosDto
{
    public int ArticuloId { get; set; }
    public string? Descripcion { get; set; }

    public double Costo { get; set; }

    public double Precio { get; set; }

    public int Existencia { get; set; }

}
