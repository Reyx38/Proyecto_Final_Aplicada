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
        return await contexto.Articulos.Select(p => new ArticulosDto()
        {
            ArticuloId = p.ArticuloId,
            Descripcion = p.Descripcion,
            Costo = p.Costo,
            Precio = p.Precio,
            Existencia = p.Existencia
        })
        .Where(criterio)
        .ToListAsync();
    }
}
