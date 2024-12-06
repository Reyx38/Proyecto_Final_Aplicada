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

	[Required(ErrorMessage = "El nombre de la ciudad es obligatorio.")]
	[StringLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres.")]
	public string? Nombre { get; set; }
	public int EstadoId { get; set; } = 1;
	public string? EstadoNombre { get; set; }
}
