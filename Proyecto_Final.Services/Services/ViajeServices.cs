using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interfaces;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Data.Models;
using Proyecto_Final.Domain.Dto;
using Proyecto_Final.Domain.Enum;
using System.Linq.Expressions;

namespace Proyecto_Final.Services.Services;

public class ViajeServices(IDbContextFactory<Context> DbFactory) : IViajeServices
{
    public async Task<ViajesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = await contexto.Viajes
       .Include(p => p.Imagenes)
       .Where(e => e.ViajeId == id)
       .Select(p => new ViajesDto()
       {
           ViajeId = p.ViajeId,
           Destino = p.Destino,
           Fecha = p.Fecha,
           Estado = p.Estado,
           Precio = p.Precio,
           TaxistaId = p.TaxistaId,
       })
       .FirstOrDefaultAsync();
        return viaje ?? new ViajesDto();
    }

    public async Task<bool> ExisteViaje(string destino, int id, int idTaxista)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes
            .AnyAsync(e => e.ViajeId != id
            && e.Destino.ToLower().Equals(destino.ToLower())
            && e.Taxista.TaxistaId == idTaxista);
    }

    private async Task<bool> Insertar(ViajesDto viajeDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = new Viajes()
        {
            ViajeId = viajeDto.ViajeId,
            Destino = viajeDto.Destino,
            Fecha = viajeDto.Fecha,
            Estado = viajeDto.Estado,
            TaxistaId = viajeDto.TaxistaId,
            Precio = viajeDto.Precio
        };
        contexto.Viajes.Add(viaje);
        var guardo = await contexto.SaveChangesAsync() > 0;
        viajeDto.ViajeId = viaje.ViajeId;
        return guardo;
    }

    private async Task<bool> Modificar(ViajesDto viajeDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = new Viajes()
        {
            ViajeId = viajeDto.ViajeId,
            Destino = viajeDto.Destino,
            Fecha = viajeDto.Fecha,
            Estado = viajeDto.Estado,
            TaxistaId = viajeDto.TaxistaId,
            Precio = viajeDto.Precio
        };
        contexto.Update(viaje);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes
            .AnyAsync(e => e.ViajeId == id);
    }
    public async Task<bool> Guardar(ViajesDto viajeDto)
    {
        if (!await Existe(viajeDto.ViajeId))
            return await Insertar(viajeDto);
        else
            return await Modificar(viajeDto);
    }

    public async Task<List<ViajesDto>> Listar(Expression<Func<ViajesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes.Select(p => new ViajesDto()
        {
            ViajeId = p.ViajeId,
            Destino = p.Destino,
            Fecha = p.Fecha,
            Estado = p.Estado,
            Precio = p.Precio,
            TaxistaId = p.TaxistaId
        })
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<bool> ActualizarEstado(ViajesDto viajeDto, EstadosViajes estado)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = await contexto.Viajes.FindAsync(viajeDto.ViajeId);
        if (viaje == null) return false;

        viaje.Estado = estado;
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

}
