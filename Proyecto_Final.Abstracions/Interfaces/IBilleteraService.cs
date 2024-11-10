using Proyecto_Final.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Abstracions.Interfaces;

public interface IBilleteraService
{
    Task<bool> Guardar(BilleteraDto billeteraDto);
    Task<bool> Eliminar(int id);
    Task<BilleteraDto> Buscar(int id);
    Task<List<BilleteraDto>> Listar(Expression<Func<BilleteraDto, bool>> criterio);
}
