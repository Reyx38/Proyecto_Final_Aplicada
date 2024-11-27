using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class EstadosTaxistasDto
{
    public int EstadoTId { get; set; }

    public string? Descripcion { get; set; }
}
