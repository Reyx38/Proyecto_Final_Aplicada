﻿using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IReservacionesServices
{
    Task<bool> Guardar(ReservacionesDto reservacionDto);
    Task<ReservacionesDto> Buscar(int id);
    Task<List<ReservacionesDto>> Listar(Expression<Func<ReservacionesDto, bool>> criterio);
    Task<bool> ExisteReservacion(int reservacionId, int ViajeId, DateTime fecha);
}
