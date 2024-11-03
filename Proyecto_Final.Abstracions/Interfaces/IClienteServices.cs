using Proyecto_Final.Domain.Dto;
using System.Linq.Expressions;

namespace Proyecto_Final.Abstracions.Interface
{
    public interface IClienteServices
    {
        Task<bool> Guardar( ClientesDto clienteDto);
        Task<bool> Eliminar(ClientesDto clienteDto);
        Task<bool> Buscar(int id);
        Task<bool> Listar(Expression<Func<ClientesDto, bool>> criterio);
        Task<bool> ExisteCliente(string nombre, int id, string correo, string provincia);
    }
}
