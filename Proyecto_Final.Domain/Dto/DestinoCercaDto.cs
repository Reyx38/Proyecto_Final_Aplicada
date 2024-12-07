using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class DestinoCercaDto
{
    public int DestinoCercaId { get; set; }

    public string? Descripcion { get; set; }

    public int CiudadId { get; set; }
    public string? Nombre { get; set; }
}
