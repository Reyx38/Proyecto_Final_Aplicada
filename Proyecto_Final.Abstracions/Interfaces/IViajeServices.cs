using Proyecto_Final.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Abstracions.Interfaces;

public interface IViajeServices
{
    Task<bool> Guardar(ViajesDto viajeDto);
    Task<ViajesDto> Buscar(int id);
    Task<List<ViajesDto>> Listar(Expression<Func<ViajesDto, bool>> criterio);
    Task<bool> ExisteViaje(string destino, int id, int idCliente, int idTaxista);
}
