using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Domain.Dto;

namespace Proyecto_Final.Services.Services;

public class EstadoServices(IDbContextFactory<ApplicationDbContext> DbFactory) 
{
    public async Task<EstadosViajesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var estado = await contexto.EstadosViajes
       .Where(e => e.EstadosVId == id)
       .Select(p => new EstadosViajesDto()
       {
           EstadosVId = p.EstadosVId,
           Descripcion = p.Descripcion
       })
       .FirstOrDefaultAsync();
        return estado ?? new EstadosViajesDto();
    }


}
