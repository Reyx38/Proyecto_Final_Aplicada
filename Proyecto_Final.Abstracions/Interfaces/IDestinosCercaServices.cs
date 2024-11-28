using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;


public interface IDestinosCercaServices
{
    Task<List<DestinoCercaDto>> Listar(Expression<Func<DestinoCercaDto, bool>> criterio);
}
