using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interface;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Domain.Dto;
using ReyAI_Trasport.Domain.Models;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Services.Services;

public class ClienteServices(IDbContextFactory<ApplicationDbContext> DbFactory) : IClienteServices
{
    public async Task<ClientesDto> Buscar(string id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = await contexto.Clientes
       .Where(e => e.Id == id)
       .Select(p => new ClientesDto()
       {
           ClienteId = p.Id,
           NickName = p.UserName,
           Correo = p.Email,
           Favoritos = p.Favoritos.Select(f => new TaxistaDto
           {
               TaxistaId = f.Id,
               NickName = f.UserName,
               Correo = f.Email,
               ExisteVehiculo = f.ExisteVehiculo,
               ExisteLicencia = f.ExisteLicencia,
           }).ToList()
       })
       .FirstOrDefaultAsync();
        return cliente ?? new ClientesDto();
    }

    public async Task<bool> Eliminar(string id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .Where(e => e.Id == id)
            .Include(p => p.Favoritos)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteCliente(string nombre, string id, string correo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(e => e.Id != id
            && e.UserName.ToLower().Equals(nombre.ToLower()) 
            && e.Email.ToLower().Equals(correo.ToLower()));
    }

    private async Task<bool> Insertar(ClientesDto clienteDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = new Clientes()
        {
			Id = clienteDto.ClienteId,
            UserName = clienteDto.NickName,
            Email = clienteDto.Correo,
            PasswordHash = clienteDto.Password,
            Favoritos = clienteDto.Favoritos.Select(f => new Taxistas
            {
				Id = f.TaxistaId,
                UserName = f.NickName,
                Email = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        };
        contexto.Clientes.Add(cliente);
        var guardo = await contexto.SaveChangesAsync() > 0;
        clienteDto.ClienteId = cliente.Id;
        return guardo;
    }

    private async Task<bool> Modificar(ClientesDto clienteDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = new Clientes()
        {
            Id = clienteDto.ClienteId,
            UserName = clienteDto.NickName,
            Email = clienteDto.Correo,
            PasswordHash = clienteDto.Password,
            Favoritos = clienteDto.Favoritos.Select(f => new Taxistas
            {
                Id = f.TaxistaId,
                UserName = f.NickName,
                Email = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        };
        contexto.Update(cliente);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(string id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(e => e.Id == id);
    }

    public async Task<bool> Guardar(ClientesDto clienteDto)
    {
        if (!await Existe(clienteDto.ClienteId))
            return await Insertar(clienteDto);
        else
            return await Modificar(clienteDto);
    }

    public async Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.Select(p => new ClientesDto()
        {
            ClienteId = p.Id,
            NickName = p.UserName,
            Correo = p.Email,
            Password = p.PasswordHash,
            Favoritos = p.Favoritos.Select(f => new TaxistaDto
            {
                TaxistaId = f.Id,
                NickName = f.UserName,
                Correo = f.Email,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        })
        .Include(p => p.Favoritos)
        .Where(criterio)
        .ToListAsync();
    }
}