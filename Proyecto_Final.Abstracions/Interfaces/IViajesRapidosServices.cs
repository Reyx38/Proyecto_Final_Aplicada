using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IViajesRapidosServices
{
    Task<bool> Guardar(ViajesRapidosDto viajeRapidoDto);
    Task<ViajesRapidosDto> Buscar(int id);
    Task<List<ViajesRapidosDto>> Listar(Expression<Func<ViajesRapidosDto, bool>> criterio);
    Task<bool> ExisteViaje(int destino, int id, string idTaxista);
}
