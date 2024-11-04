using Proyecto_Final.Domain.Dto;
using System.Linq.Expressions;

namespace Proyecto_Final.Abstracions.Interface
{
    public interface ITaxistaServices
    {
        Task<bool> Guardar(TaxistaDto taxistaDto);
        Task<bool> Eliminar(int id);
        Task<TaxistaDto> Buscar(int id);
        Task<List<TaxistaDto>> Listar(Expression<Func<TaxistaDto, bool>> criterio);
        Task<bool> ExisteTaxista(string nombre, int id, string correo);
    }
}
