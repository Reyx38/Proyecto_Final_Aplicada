using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Abstracions.Interface;

public interface ITaxistaServices
{
    Task<bool> Guardar(TaxistaDto taxistaDto);
    Task<bool> Eliminar(string id);
    Task<TaxistaDto> Buscar(string id);
    Task<List<TaxistaDto>> Listar(Expression<Func<TaxistaDto, bool>> criterio);
    Task<bool> ExisteTaxista(string nombre, string id, string correo);
}
