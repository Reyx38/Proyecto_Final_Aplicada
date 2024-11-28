using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Abstracions.Interfaces;


public interface IDestinosCercaServices
{
    Task<List<DestinoCercaDto>> Listar(Expression<Func<DestinoCercaDto, bool>> criterio);
}
