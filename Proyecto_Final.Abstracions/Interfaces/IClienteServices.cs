using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Abstracions.Interface
{
    public interface IClienteServices
    {
        Task<bool> Guardar( ClientesDto clienteDto);
        Task<bool> Eliminar(string id);
        Task<ClientesDto> Buscar(string id);
        Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio);
        Task<bool> ExisteCliente(string nombre, string id, string correo);
    }
}
