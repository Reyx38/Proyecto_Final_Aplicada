using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Domain.Dto;

public class CiudadesDto
{
    public int CiudadId { get; set; }

    public string? Nombre { get; set; }
}
