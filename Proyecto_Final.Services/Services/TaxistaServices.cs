using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interface;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Domain.Dto;
using System.Linq.Expressions;

namespace Proyecto_Final.Services.Services
{
    public class TaxistaServices(IDbContextFactory<Context> DbFactory) : ITaxistaServices
    {
        public Task<bool> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TaxistaDto taxistaDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteTaxista(string nombre, int id, string correo, string provincia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(TaxistaDto taxistaDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Listar(Expression<Func<TaxistaDto, bool>> criterio)
        {
            throw new NotImplementedException();
        }
    }
}
