using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interface;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Data.Models;
using ReyAI_Trasport.Domain.Dto;
using ReyAI_Trasport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReyAI_Trasport.Services.Services;

public class PagosServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IPagosServices
{
    public async Task<PagosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var pago = await contexto.Pagos
       .Where(e => e.PagoId == id)
       .Select(p => new PagosDto()
       {
            PagoId = p.PagoId,
            Monto = p.Monto,
            ReservacionId = p.ReservacionId
       })
       .FirstOrDefaultAsync();
        return pago ?? new PagosDto();
    }

    public async Task<bool> ExistePago(int pagoId, int reservacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pagos
            .AnyAsync(e => e.PagoId != pagoId
            && e.ReservacionId == reservacionId);
    }

    private async Task<bool> Insertar(PagosDto pagoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var pago = new Pagos()
        {
            PagoId = pagoDto.PagoId,
            Monto = pagoDto.Monto,
            ReservacionId = pagoDto.ReservacionId
        };
        contexto.Pagos.Add(pago);
        var guardo = await contexto.SaveChangesAsync() > 0;
        pagoDto.PagoId = pago.PagoId;
        return guardo;
    }

    private async Task<bool> Modificar(PagosDto pagoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var pago = new Pagos()
        {
            PagoId = pagoDto.PagoId,
            Monto = pagoDto.Monto,
            ReservacionId = pagoDto.ReservacionId
        };
        contexto.Update(pago);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pagos
            .AnyAsync(e => e.PagoId == id);
    }

    public async Task<bool> Guardar(PagosDto pagoDto)
    {
        if (!await Existe(pagoDto.PagoId))
            return await Insertar(pagoDto);
        else
            return await Modificar(pagoDto);
    }

    public async Task<List<PagosDto>> Listar(Expression<Func<PagosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pagos.Select(f => new PagosDto()
        {
            PagoId = f.PagoId,
            Monto = f.Monto,
            ReservacionId = f.ReservacionId
        })
        .Where(criterio)
        .ToListAsync();
    }
}
