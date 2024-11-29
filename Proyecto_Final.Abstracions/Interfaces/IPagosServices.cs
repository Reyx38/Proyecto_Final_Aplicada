using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IPagosServices
{
    Task<bool> Guardar(PagosDto pagoDto);
    Task<PagosDto> Buscar(int id);
    Task<List<PagosDto>> Listar(Expression<Func<PagosDto, bool>> criterio);
    Task<bool> ExistePago(int pagoId, int reservacionId);
}
