using Proyecto_Final.Domain.Dto;
using System.Linq.Expressions;

namespace Proyecto_Final.Abstracions.Interface
{
    public interface IClienteServices
    {
        Task<bool> Guardar( ClientesDto clienteDto);
        Task<bool> Eliminar(int id);
        Task<ClientesDto> Buscar(int id);
        Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio);
        Task<bool> ExisteCliente(string nombre, int id, string correo);
    }
}
