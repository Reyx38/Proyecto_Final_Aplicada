using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Services.Services;

public class DestinosCercasServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IDestinosCercaServices
{
    public async Task<List<DestinoCercaDto>> Listar(Expression<Func<DestinoCercaDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.DestinosCerca.Select(p => new DestinoCercaDto()
        {
            DestinoCercaId = p.DestinoCercaId,
            Descripcion = p.Descripcion,
            CiudadId = p.CiudadId
        })
        .Where(criterio)
        .ToListAsync();
    }
}
