using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IReservacionesServices
{
    Task<bool> Guardar(ReservacionesDto reservacionDto);
    Task<ReservacionesDto> Buscar(int id);
    Task<List<ReservacionesDto>> Listar(Expression<Func<ReservacionesDto, bool>> criterio);
    Task<bool> ExisteReservacion(int reservacionId, int ViajeId, DateTime fecha);
}
