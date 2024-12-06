using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Domain.Dto;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Data.Models;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Services.Services;

public class CiudadServices(IDbContextFactory<ApplicationDbContext> DbFactory) : ICiudadesServices
{
    public async Task<CiudadesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ciudad = await contexto.Ciudades
       .Where(e => e.CiudadId == id)
       .Select(p => new CiudadesDto()
       {
           CiudadId = p.CiudadId,
           Nombre = p.Nombre,
           EstadoId = p.EstadoCId,
           EstadoNombre = p.CiudadesEstados.Descripcion
       })
       .FirstOrDefaultAsync();
        return ciudad ?? new CiudadesDto();
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades
            .Where(e => e.CiudadId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteCiudad(string nombre, int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades
            .AnyAsync(e => e.CiudadId != id
            && e.Nombre.ToLower().Equals(nombre.ToLower()));
    }

    private async Task<bool> Insertar(CiudadesDto ciudadesDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ciudad = new Ciudades()
        {
            CiudadId = ciudadesDto.CiudadId,
            Nombre = ciudadesDto.Nombre,
            EstadoCId = ciudadesDto.EstadoId

        };
        contexto.Ciudades.Add(ciudad);
        var guardo = await contexto.SaveChangesAsync() > 0;
        ciudadesDto.CiudadId = ciudad.CiudadId;
        return guardo;
    }

    private async Task<bool> Modificar(CiudadesDto ciudadesDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ciudad = new Ciudades()
        {
            CiudadId = ciudadesDto.CiudadId,
            Nombre = ciudadesDto.Nombre,
        };
        contexto.Update(ciudad);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades
            .AnyAsync(e => e.CiudadId == id);
    }

    public async Task<bool> Guardar(CiudadesDto ciudadDto)
    {
        if (!await Existe(ciudadDto.CiudadId))
            return await Insertar(ciudadDto);
        else
            return await Modificar(ciudadDto);
    }

    public async Task<List<CiudadesDto>> Listar(Expression<Func<CiudadesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.Select(p => new CiudadesDto()
        {
            CiudadId = p.CiudadId,
            Nombre = p.Nombre,
            EstadoId = p.EstadoCId,
            EstadoNombre = p.CiudadesEstados.Descripcion
        })
        .Where(criterio)
        .ToListAsync();
    }
}
