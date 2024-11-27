using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IViajeServices
{
    Task<bool> Guardar(ViajesDto viajeDto);
    Task<ViajesDto> Buscar(int id);
    Task<List<ViajesDto>> Listar(Expression<Func<ViajesDto, bool>> criterio);
    Task<bool> ExisteViaje(int destino, int id, string idTaxista);
}
