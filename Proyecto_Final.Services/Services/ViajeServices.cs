using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interfaces;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Data.Models;
using Proyecto_Final.Domain.Dto;
using Proyecto_Final.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Final.Services.Services;

public class ViajeServices(IDbContextFactory<Context> DbFactory) : IViajeServices
{
    public async Task<ViajesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = await contexto.Viajes
       .Where(e => e.ViajeId == id)
       .Select(p => new ViajesDto()
       {
           ViajeId = p.ViajeId,
           UbicacionInicial = p.UbicacionInicial,
           Destino = p.Destino,
           Fecha = p.Fecha,
           Tiempo = p.Tiempo,
           Estado = p.Estado,
           ClienteId = p.ClienteId,
           TaxistaId = p.TaxistaId
       })
       .FirstOrDefaultAsync();
        return viaje ?? new ViajesDto();
    }

    public async Task<bool> ExisteViaje(string destino, int id, int idCliente, int idTaxista)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes
            .AnyAsync(e => e.ViajeId != id
            && e.Destino.ToLower().Equals(destino.ToLower())
            && e.Cliente.ClienteId == idCliente
            && e.Taxista.TaxistaId == idTaxista);
    }

    private async Task<bool> Insertar(ViajesDto viajeDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = new Viajes()
        {
            ViajeId = viajeDto.ViajeId,
            UbicacionInicial = viajeDto.UbicacionInicial,
            Destino = viajeDto.Destino,
            Fecha = viajeDto.Fecha,
            Tiempo = viajeDto.Tiempo,
            Estado = viajeDto.Estado,
            ClienteId = viajeDto.ClienteId,
            TaxistaId = viajeDto.TaxistaId
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
            UbicacionInicial = viajeDto.UbicacionInicial,
            Destino = viajeDto.Destino,
            Fecha = viajeDto.Fecha,
            Tiempo = viajeDto.Tiempo,
            Estado = viajeDto.Estado,
            ClienteId = viajeDto.ClienteId,
            TaxistaId = viajeDto.TaxistaId
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
            UbicacionInicial = p.UbicacionInicial,
            Destino = p.Destino,
            Fecha = p.Fecha,
            Tiempo = p.Tiempo,
            Estado = p.Estado,
            ClienteId = p.ClienteId,
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
