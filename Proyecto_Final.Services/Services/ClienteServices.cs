using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interface;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Data.Models;
using Proyecto_Final.Domain.Dto;
using Proyecto_Final.Domain.Enum;
using System.Linq.Expressions;

namespace Proyecto_Final.Services.Services;

public class ClienteServices(IDbContextFactory<Context> DbFactory) : IClienteServices
{
    public async Task<ClientesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = await contexto.Clientes
       .Where(e => e.ClienteId == id)
       .Select(p => new ClientesDto()
       {
           ClienteId = p.ClienteId,
           NickName = p.NickName,
           FechaNacimiento = p.FechaNacimiento,
           Correo = p.Correo,
           Password = p.Password,
           Favoritos = p.Favoritos.Select(f => new TaxistaDto
           {
               TaxistaId = f.TaxistaId,
               NickName = f.NickName,
               Correo = f.Correo,
               ExisteVehiculo = f.ExisteVehiculo,
               ExisteLicencia = f.ExisteLicencia,
           }).ToList()
       })
       .FirstOrDefaultAsync();
        return cliente ?? new ClientesDto();
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .Where(e => e.ClienteId == id)
            .Include(p => p.Favoritos)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteCliente(string nombre, int id, string correo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(e => e.ClienteId != id
            && e.NickName.ToLower().Equals(nombre.ToLower()) 
            && e.Correo.ToLower().Equals(correo.ToLower()));
    }

    private async Task<bool> Insertar(ClientesDto clienteDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = new Clientes()
        {
            ClienteId = clienteDto.ClienteId,
            NickName = clienteDto.NickName,
            FechaNacimiento = clienteDto.FechaNacimiento,
            Correo = clienteDto.Correo,
            Password = clienteDto.Password,
            Role = Roles.Cliente,
            Favoritos = clienteDto.Favoritos.Select(f => new Taxistas
            {
                TaxistaId = f.TaxistaId,
                NickName = f.NickName,
                Correo = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        };
        contexto.Clientes.Add(cliente);
        var guardo = await contexto.SaveChangesAsync() > 0;
        clienteDto.ClienteId = cliente.ClienteId;
        return guardo;
    }

    private async Task<bool> Modificar(ClientesDto clienteDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cliente = new Clientes()
        {
            ClienteId = clienteDto.ClienteId,
            NickName = clienteDto.NickName,
            FechaNacimiento = clienteDto.FechaNacimiento,
            Correo = clienteDto.Correo,
            Password = clienteDto.Password,
            Favoritos = clienteDto.Favoritos.Select(f => new Taxistas
            {
                TaxistaId = f.TaxistaId,
                NickName = f.NickName,
                Correo = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        };
        contexto.Update(cliente);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(e => e.ClienteId == id);
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
            ClienteId = p.ClienteId,
            NickName = p.NickName,
            FechaNacimiento = p.FechaNacimiento,
            Correo = p.Correo,
            Password = p.Password,
            Favoritos = p.Favoritos.Select(f => new TaxistaDto
            {
                TaxistaId = f.TaxistaId,
                NickName = f.NickName,
                Correo = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
            }).ToList()
        })
        .Include(p => p.Favoritos)
        .Where(criterio)
        .ToListAsync();
    }
}