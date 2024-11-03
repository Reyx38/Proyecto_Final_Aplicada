using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interface;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Domain.Dto;
using System.Linq.Expressions;

namespace Proyecto_Final.Services.Services
{
    public class ClienteServices(IDbContextFactory<Context> DbFactory) : IClienteServices
    {
        public Task<bool> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(ClientesDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteCliente(string nombre, int id, string correo, string provincia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(ClientesDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Listar(Expression<Func<ClientesDto, bool>> criterio)
        {
            throw new NotImplementedException();
        }
    }
}
