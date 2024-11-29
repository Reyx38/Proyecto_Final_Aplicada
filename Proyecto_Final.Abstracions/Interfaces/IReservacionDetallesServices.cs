using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IReservacionDetallesServices
{
    Task<List<ArticulosDto>> Listar(Expression<Func<ArticulosDto, bool>> criterio);
}
