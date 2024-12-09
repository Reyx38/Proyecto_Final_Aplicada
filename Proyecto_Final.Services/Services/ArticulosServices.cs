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

public class ArticulosServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IArticulosServices
{
    public async Task<ArticulosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var articulo = await contexto.ArticulosT
       .Where(e => e.ArticuloTId == id)
       .Select(p => new ArticulosDto()
       {
           ArticuloId = p.ArticuloTId,
           Descripcion = p.Descripcion,
           Costo = p.Costo,
           Precio = p.Precio,
           Existencia = p.Existencia
       })
       .FirstOrDefaultAsync();
        return articulo ?? new ArticulosDto();
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosT
            .Where(e => e.ArticuloTId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteArticulo(string nombre, int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosT
            .AnyAsync(e => e.ArticuloTId != id
            && e.Descripcion.ToLower().Equals(nombre.ToLower()));
    }

    private async Task<bool> Insertar(ArticulosDto articuloDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var articulo = new ArticulosT()
        {
            ArticuloTId = articuloDto.ArticuloId,
            Descripcion = articuloDto.Descripcion,
            Costo = articuloDto.Costo,
            Precio = articuloDto.Precio,
            Existencia = articuloDto.Existencia
        };
        contexto.ArticulosT.Add(articulo);
        var guardo = await contexto.SaveChangesAsync() > 0;
        articuloDto.ArticuloId = articulo.ArticuloTId;
        return guardo;
    }

    private async Task<bool> Modificar(ArticulosDto articuloDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var articulo = new ArticulosT()
        {
            ArticuloTId = articuloDto.ArticuloId,
            Descripcion = articuloDto.Descripcion,
            Costo = articuloDto.Costo,
            Precio = articuloDto.Precio,
            Existencia = articuloDto.Existencia
        };
        contexto.Update(articulo);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosT
            .AnyAsync(e => e.ArticuloTId == id);
    }

    public async Task<bool> Guardar(ArticulosDto articuloDto)
    {
        if (!await Existe(articuloDto.ArticuloId))
            return await Insertar(articuloDto);
        else
            return await Modificar(articuloDto);
    }

    public async Task<List<ArticulosDto>> Listar(Expression<Func<ArticulosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosT.Select(f => new ArticulosDto()
        {
            ArticuloId = f.ArticuloTId,
            Descripcion = f.Descripcion,
            Costo = f.Costo,
            Precio = f.Precio,
            Existencia = f.Existencia

        })
        .Where(criterio)
        .ToListAsync();
    }
}
