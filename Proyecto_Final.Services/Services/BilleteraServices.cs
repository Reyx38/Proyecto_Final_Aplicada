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

namespace Proyecto_Final.Services.Services;

public class BilleteraServices(IDbContextFactory<Context> DbFactory) : IBilleteraService
{
    public async Task<BilleteraDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var billetera = await contexto.Billeteras
       .Where(e => e.BilleteraId == id)
       .Select(p => new BilleteraDto()
       {
           BilleteraId = p.BilleteraId,
           Saldo = p.Saldo,
           Transacciones = p.Transacciones.Select(f => new TransaccionesDto() 
           {
               TransaccionId = f.TransaccionId,
               Fecha = f.Fecha,
               Monto = f.Monto,
               Tipo = f.Tipo
           }).ToList()
       })
       .FirstOrDefaultAsync();
        return billetera ?? new BilleteraDto();
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Billeteras
            .Where(e => e.BilleteraId == id)
            .Include(p => p.Transacciones)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(BilleteraDto billeteraDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var billetera = new Billeteras()
        {
            BilleteraId = billeteraDto.BilleteraId,
            Saldo = billeteraDto.Saldo,
            Transacciones = billeteraDto.Transacciones.Select(f => new Transacciones
            {
                TransaccionId = f.TransaccionId,
                Fecha = f.Fecha,
                Monto = f.Monto,
                Tipo = f.Tipo
            }).ToList()
        };
        contexto.Billeteras.Add(billetera);
        var guardo = await contexto.SaveChangesAsync() > 0;
        billeteraDto.BilleteraId = billetera.BilleteraId;
        return guardo;
    }

    private async Task<bool> Modificar(BilleteraDto billeteraDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var billetera = new Billeteras()
        {
            BilleteraId = billeteraDto.BilleteraId,
            Saldo = billeteraDto.Saldo,
            Transacciones = billeteraDto.Transacciones.Select(f => new Transacciones
            {
                TransaccionId = f.TransaccionId,
                Fecha = f.Fecha,
                Monto = f.Monto,
                Tipo = f.Tipo
            }).ToList()
        };
        contexto.Update(billetera);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Billeteras
            .AnyAsync(e => e.BilleteraId == id);
    }
    public async Task<bool> Guardar(BilleteraDto billeteraDto)
    {
        if (!await Existe(billeteraDto.BilleteraId))
            return await Insertar(billeteraDto);
        else
            return await Modificar(billeteraDto);
    }

    public async Task<List<BilleteraDto>> Listar(Expression<Func<BilleteraDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Billeteras.Select(p => new BilleteraDto()
        {
            BilleteraId = p.BilleteraId,
            Saldo = p.Saldo,
            Transacciones = p.Transacciones.Select(f => new TransaccionesDto()
            {
                TransaccionId = f.TransaccionId,
                Fecha = f.Fecha,
                Monto = f.Monto,
                Tipo = f.Tipo
            }).ToList()
        })
        .Include(p => p.Transacciones)
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<bool> ActualizarSaldoBilletera(int billeteraId, double monto, TipoTransaccion tipoTransaccion)
    {
        var billeteraDto = await Buscar(billeteraId);

        if (billeteraDto.BilleteraId == 0)
        {
            return false;
        }

        switch (tipoTransaccion)
        {
            case TipoTransaccion.PagoViaje:
                // Disminuir el saldo si es un pago 
                if (billeteraDto.Saldo < monto)
                {
                    return false;
                }
                billeteraDto.Saldo -= monto;
                break;

            case TipoTransaccion.Recarga:
            case TipoTransaccion.RecibirPago:
                // Aumentar el saldo si es una recarga o recibir pago
                billeteraDto.Saldo += monto;
                break;

            default:
                return false;
        }
        return await Modificar(billeteraDto);
    }
}
