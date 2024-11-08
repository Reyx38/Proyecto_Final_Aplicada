using Proyecto_Final.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Abstracions.Interfaces;

public interface ITransaccionServices
{
    Task<List<TransaccionesDto>> Listar(Expression<Func<TransaccionesDto, bool>> criterio);
}
