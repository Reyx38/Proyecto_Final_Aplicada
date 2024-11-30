using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Domain.Dto;
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
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace ReyAI_Trasport.Services.Services;

public class ReservacionesServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IReservacionesServices
{
    public async Task<ReservacionesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var reserva = await contexto.Reservaciones
       .Include(p => p.ReservacionDetalles)
       .Where(e => e.ReservacionId == id)
       .Select(p => new ReservacionesDto()
       {
           ReservacionId = p.ReservacionId,
           Fecha = p.Fecha,
           ViajeId = p.ViajeId,
           Pago = p.Pago,
           Recibo = p.Recibo,
           CantidadPasajeros = p.CantidadPasajeros,
           Monto = p.Monto,
           EstadoId = p.EstadoId,
           ClienteId = p.ClienteId,
           ReservacionDetalles = p.ReservacionDetalles.Select(i => new ReservacionDetallesDto()
           {
			   DetalleId = i.DetalleId,
			   ArticuloId = i.ArticuloId,
			   Cantidad = i.Cantidad,
			   Precio = i.Precio,
			   ReservacionId = p.ReservacionId
		   }).ToList()
       })
       .FirstOrDefaultAsync();
        return reserva ?? new ReservacionesDto();
    }

    public async Task<bool> ExisteReservacion(int reservacionId, int ViajeId, DateTime fecha)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Reservaciones
            .AnyAsync(e => e.ReservacionId != reservacionId
            && e.ViajeId == ViajeId && e.Fecha == fecha);
    }

    private async Task<bool> Insertar(ReservacionesDto reservacionDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
		await AfectarCantidad(reservacionDto.ReservacionDetalles.ToArray(), true);
		var reserva = new Reservaciones()
        {
            ReservacionId = reservacionDto.ReservacionId,
            Fecha = reservacionDto.Fecha,
            ViajeId = reservacionDto.ViajeId,
            Pago = reservacionDto.Pago,
            Recibo = reservacionDto.Recibo,
			CantidadPasajeros = reservacionDto.CantidadPasajeros,
			Monto = reservacionDto.Monto,
            EstadoId = reservacionDto.EstadoId,
            ClienteId = reservacionDto.ClienteId,
			ReservacionDetalles = reservacionDto.ReservacionDetalles.Select(detalle => new ReservacionDetalles
            {
                DetalleId = detalle.DetalleId,
                ArticuloId = detalle.ArticuloId,
                Cantidad = detalle.Cantidad,
                Precio = detalle.Precio,
                ReservacionId = detalle.ReservacionId
            }).ToList()
        };
        contexto.Reservaciones.Add(reserva);
        var guardo = await contexto.SaveChangesAsync() > 0;
        reservacionDto.ReservacionId = reserva.ReservacionId;
        return guardo;
    }

    private async Task<bool> Modificar(ReservacionesDto reservacionDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
		await AfectarCantidad(reservacionDto.ReservacionDetalles.ToArray(), true);
		var reserva = new Reservaciones()
        {
            ReservacionId = reservacionDto.ReservacionId,
            Fecha = reservacionDto.Fecha,
            ViajeId = reservacionDto.ViajeId,
            Pago = reservacionDto.Pago,
            Recibo = reservacionDto.Recibo,
			CantidadPasajeros = reservacionDto.CantidadPasajeros,
			Monto = reservacionDto.Monto,
            EstadoId = reservacionDto.EstadoId,
            ClienteId = reservacionDto.ClienteId,
			ReservacionDetalles = reservacionDto.ReservacionDetalles.Select(detalle => new ReservacionDetalles
            {
                DetalleId = detalle.DetalleId,
                ArticuloId = detalle.ArticuloId,
                Cantidad = detalle.Cantidad,
                Precio = detalle.Precio,
                ReservacionId = detalle.ReservacionId
            }).ToList()
        };
        contexto.Update(reserva);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Reservaciones
            .AnyAsync(e => e.ReservacionId == id);
    }

    public async Task<bool> Guardar(ReservacionesDto reservacionDto)
    {
        if (!await Existe(reservacionDto.ReservacionId))
            return await Insertar(reservacionDto);
        else
            return await Modificar(reservacionDto);
    }

    public async Task<List<ReservacionesDto>> Listar(Expression<Func<ReservacionesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Reservaciones
        .Include(p => p.ReservacionDetalles)
        .Select(p => new ReservacionesDto()
        {
            ReservacionId = p.ReservacionId,
            Fecha = p.Fecha,
            ViajeId = p.ViajeId,
            Pago = p.Pago,
            Recibo = p.Recibo,
			CantidadPasajeros = p.CantidadPasajeros,
			Monto = p.Monto,
            EstadoId = p.EstadoId,
            EstadosReservacionesDto = p.Estado.Descripcion,
            ViajeDto = p.Viaje.Ciudad.Nombre,
            ClienteId = p.ClienteId,
			ReservacionDetalles = p.ReservacionDetalles.Select(i => new ReservacionDetallesDto()
			{
				DetalleId = i.DetalleId,
				ArticuloId = i.ArticuloId,
				Cantidad = i.Cantidad,
				Precio = i.Precio,
				ReservacionId = p.ReservacionId
			}).ToList()
		})
        .Where(criterio)
        .ToListAsync();
    }

	public async Task AfectarCantidad(ReservacionDetallesDto[] detalles, bool resta)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		foreach (var item in detalles)
		{
			var detalle = await contexto.Articulos.SingleOrDefaultAsync(d => d.ArticuloId == item.ArticuloId);
			if (resta)
				detalle.Existencia -= item.Cantidad;
			else
				detalle.Existencia += item.Cantidad;
		}
		await contexto.SaveChangesAsync();
	}
}
