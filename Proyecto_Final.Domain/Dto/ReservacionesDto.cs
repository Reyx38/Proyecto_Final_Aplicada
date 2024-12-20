﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ReyAI_Trasport.Domain.Dto;

public class ReservacionesDto
{
    public int ReservacionId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int ViajeId { get; set; }
    public string? ViajeDto { get; set; }

    public bool Pago { get; set; }
    public string? Recibo { get; set; }
    public double Monto { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int EstadoId { get; set; }
    public  string? EstadosReservacionesDto { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string? ClienteId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int CantidadPasajeros { get; set; }

	public ICollection<ReservacionDetallesDto> ReservacionDetalles { get; set; } = new List<ReservacionDetallesDto>();
}
