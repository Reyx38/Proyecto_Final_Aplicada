using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Data.Models;
using ReyAI_Trasport.Domain.Dto;
using System.Linq.Expressions;

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
            CiudadId = p.CiudadId,
			Nombre = p.Ciudad.Nombre
		})
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<DestinoCercaDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var destino = await contexto.DestinosCerca
       .Where(e => e.DestinoCercaId == id)
       .Select(p => new DestinoCercaDto()
       {
           DestinoCercaId = p.DestinoCercaId,
           Descripcion = p.Descripcion,
           CiudadId = p.CiudadId,
		   Nombre = p.Ciudad.Nombre
	   })
       .FirstOrDefaultAsync();
        return destino ?? new DestinoCercaDto();
    }
	private async Task<bool> Insertar(DestinoCercaDto destinoCercaDto)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var destinosCerca = new DestinosCerca()
		{
			DestinoCercaId = destinoCercaDto.DestinoCercaId,
			Descripcion = destinoCercaDto.Descripcion,
			CiudadId = destinoCercaDto.CiudadId
		};
		await contexto.DestinosCerca.AddAsync(destinosCerca);
		var guardo = await contexto.SaveChangesAsync() > 0;
		return guardo;
	}


	private async Task<bool> Modificar(DestinoCercaDto destinoCercaDto)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var destinosCerca = new DestinosCerca()
		{
			DestinoCercaId = destinoCercaDto.DestinoCercaId,
			Descripcion = destinoCercaDto.Descripcion,
			CiudadId = destinoCercaDto.CiudadId
		};
		contexto.Update(destinosCerca);
		var modificado = await contexto.SaveChangesAsync() > 0;
		return modificado;
	}

	private async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.DestinosCerca
			.AnyAsync(e => e.DestinoCercaId == id);
	}
	public async Task<bool> Guardar(DestinoCercaDto destinoCercaDto)
	{
		if (!await Existe(destinoCercaDto.DestinoCercaId))
			return await Insertar(destinoCercaDto);
		else
			return await Modificar(destinoCercaDto);
	}
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.DestinosCerca
            .Where(m => m.DestinoCercaId == id)
            .ExecuteDeleteAsync() > 0;
    }


}
