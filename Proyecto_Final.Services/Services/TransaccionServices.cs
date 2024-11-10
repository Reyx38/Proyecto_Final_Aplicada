using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interfaces;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Services.Services;

public class TransaccionServices(IDbContextFactory<Context> DbFactory) : ITransaccionServices
{
    public async Task<List<TransaccionesDto>> Listar(Expression<Func<TransaccionesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Transacciones.Select(p => new TransaccionesDto()
        {
            TransaccionId = p.TransaccionId,
            Fecha = p.Fecha,
            Monto = p.Monto,
            Tipo = p.Tipo
        })
        .Where(criterio)
        .ToListAsync();
    }
}
