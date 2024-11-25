using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Domain.Dto;

public class ImagenDto
{
    public int Id { get; set; }
    public string ImagenUrl { get; set; }
    public string Alt { get; set; }
    public string Titulo { get; set; }
    public int ViajesId { get; set; }
}
