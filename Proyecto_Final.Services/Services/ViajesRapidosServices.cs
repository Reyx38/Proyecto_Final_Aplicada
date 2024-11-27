using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Data.Models;
using ReyAI_Trasport.Domain.Dto;
using ReyAI_Trasport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Services.Services;

public class ViajesRapidosServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IViajesRapidosServices
{
    public async Task<ViajesRapidosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = await contexto.ViajesRapidos
       .Where(e => e.ViajeRapidoId == id)
       .Select(p => new ViajesRapidosDto()
       {
           ViajeRapidoId = p.ViajeRapidoId,
           DestinoCercaId = p.DestinoCercaId,
           Fecha = p.Fecha,
           EstadoVId = p.EstadoVId,
           Precio = p.Precio,
           TaxistaId = p.TaxistaId,
       })
       .FirstOrDefaultAsync();
        return viaje ?? new ViajesRapidosDto();
    }

    public async Task<bool> ExisteViaje(int destino, int id, string idTaxista)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesRapidos
            .AnyAsync(e => e.ViajeRapidoId != id
            && e.DestinoCercaId == destino
            && e.Taxista.Id == idTaxista);
    }

    private async Task<bool> Insertar(ViajesRapidosDto viajeRapidoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = new ViajesRapidos()
        {
            ViajeRapidoId = viajeRapidoDto.ViajeRapidoId,
            DestinoCercaId = viajeRapidoDto.DestinoCercaId,
            Fecha = viajeRapidoDto.Fecha,
            EstadoVId = viajeRapidoDto.EstadoVId,
            TaxistaId = viajeRapidoDto.TaxistaId,
            Precio = viajeRapidoDto.Precio
        };
        contexto.ViajesRapidos.Add(viaje);
        var guardo = await contexto.SaveChangesAsync() > 0;
        viajeRapidoDto.ViajeRapidoId = viaje.ViajeRapidoId;
        return guardo;
    }

    private async Task<bool> Modificar(ViajesRapidosDto viajeRapidoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var viaje = new ViajesRapidos()
        {
            ViajeRapidoId = viajeRapidoDto.ViajeRapidoId,
            DestinoCercaId = viajeRapidoDto.DestinoCercaId,
            Fecha = viajeRapidoDto.Fecha,
            EstadoVId = viajeRapidoDto.EstadoVId,
            TaxistaId = viajeRapidoDto.TaxistaId,
            Precio = viajeRapidoDto.Precio
        };
        contexto.Update(viaje);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesRapidos
            .AnyAsync(e => e.ViajeRapidoId == id);
    }

    public async Task<bool> Guardar(ViajesRapidosDto viajeRapidoDto)
    {
        if (!await Existe(viajeRapidoDto.ViajeRapidoId))
            return await Insertar(viajeRapidoDto);
        else
            return await Modificar(viajeRapidoDto);
    }

    public async Task<List<ViajesRapidosDto>> Listar(Expression<Func<ViajesRapidosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesRapidos.Select(p => new ViajesRapidosDto()
        {
            ViajeRapidoId = p.ViajeRapidoId,
            DestinoCercaId = p.DestinoCercaId,
            Fecha = p.Fecha,
            EstadoVId = p.EstadoVId,
            Precio = p.Precio,
            TaxistaId = p.TaxistaId
        })
        .Where(criterio)
        .ToListAsync();
    }
}
