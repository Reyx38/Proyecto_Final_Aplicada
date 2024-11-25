using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Data.Models;

public class Imagen
{
	[Key]
	public int ImagenId { get; set; }
	public string ImagenUrl { get; set; }
	public string Alt { get; set; }
	public string Titulo { get; set; }
	public int ViajeId { get; set; }
	[ForeignKey("ViajeId")]
    public Viajes? Viaje { get; set; }
}
