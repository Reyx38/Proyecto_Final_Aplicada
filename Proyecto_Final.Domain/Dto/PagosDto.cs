using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Domain.Dto;

public class PagosDto
{
    public int PagoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public double Monto { get; set; }
    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public int ReservacionId { get; set; }
    public string? ClienteId { get; set; }
}
