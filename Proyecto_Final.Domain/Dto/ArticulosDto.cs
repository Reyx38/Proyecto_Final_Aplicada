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

    [Required(ErrorMessage = "Campo obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Existencia { get; set; }

}
