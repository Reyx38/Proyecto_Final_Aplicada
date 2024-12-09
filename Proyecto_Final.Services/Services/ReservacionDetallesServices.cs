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

public class ReservacionDetallesServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IReservacionDetallesServices
{
    public async Task<List<ArticulosDto>> Listar(Expression<Func<ArticulosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosT.Select(p => new ArticulosDto()
        {
            ArticuloId = p.ArticuloTId,
            Descripcion = p.Descripcion,
            Costo = p.Costo,
            Precio = p.Precio,
            Existencia = p.Existencia
        })
        .Where(criterio)
        .ToListAsync();
    }

	public async Task<bool> Eliminar(int detalleId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		var detalle = await contexto.ReservacionDetalles
			.Include(d => d.Articulo)
			.FirstOrDefaultAsync(d => d.DetalleId == detalleId);

		if (detalle != null)
		{
			var detallesDto = new ReservacionDetallesDto[]
			{
			new ReservacionDetallesDto
			{
				ArticuloId = detalle.ArticuloTId,
				Cantidad = detalle.Cantidad
			}
			};

			await AfectarCantidad(detallesDto, false); 

			contexto.ReservacionDetalles.Remove(detalle);

			await contexto.SaveChangesAsync();
			return true;
		}

		return false;
	}


	public async Task AfectarCantidad(ReservacionDetallesDto[] detalles, bool resta)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		foreach (var item in detalles)
		{
			var detalle = await contexto.ArticulosT.SingleOrDefaultAsync(d => d.ArticuloTId == item.ArticuloId);
			if (resta)
				detalle.Existencia -= item.Cantidad;
			else
				detalle.Existencia += item.Cantidad;
		}
		await contexto.SaveChangesAsync();
	}
}
