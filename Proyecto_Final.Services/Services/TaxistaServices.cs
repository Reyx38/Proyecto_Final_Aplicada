using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Abstracions.Interface;
using ReyAI_Trasport.Data.Contexto;
using ReyAI_Trasport.Domain.Dto;
using ReyAI_Trasport.Domain.Models;
using System.Linq.Expressions;

namespace ReyAI_Trasport.Services.Services
{
	public class TaxistaServices(IDbContextFactory<ApplicationDbContext> DbFactory) : ITaxistaServices
    {
        public async Task<TaxistaDto> Buscar(string id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = await contexto.Taxistas
           .Where(e => e.Id.ToLower().Equals(id.ToLower()))
           .Select(p => new TaxistaDto()
           {
               TaxistaId = p.Id,
               NickName = p.UserName,
               Password = p.PasswordHash,
               ExisteVehiculo = p.ExisteVehiculo,
               ExisteLicencia = p.ExisteLicencia,
               EstadoTId = p.EstadoTId,
               CiudadId = p.CiudadId
           })
           .FirstOrDefaultAsync();
            return taxista ?? new TaxistaDto();
        }

        public async Task<bool> Eliminar(string id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteTaxista(string nombre, string id, string correo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .AnyAsync(e => e.Id != id
                && e.UserName.ToLower().Equals(nombre.ToLower())
                && e.Email.ToLower().Equals(correo.ToLower()));
        }

        private async Task<bool> Insertar(TaxistaDto taxistaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = new Taxistas()
            {
                Id = taxistaDto.TaxistaId,
                UserName = taxistaDto.NickName,
                PasswordHash = taxistaDto.Password,
                ExisteVehiculo = taxistaDto.ExisteVehiculo,
                ExisteLicencia = taxistaDto.ExisteLicencia,
                EstadoTId = taxistaDto.EstadoTId, 
                CiudadId = taxistaDto.CiudadId
            };
            contexto.Taxistas.Add(taxista);
            var guardo = await contexto.SaveChangesAsync() > 0;
            taxistaDto.TaxistaId = taxista.Id;
            return guardo;
        }

        private async Task<bool> Modificar(TaxistaDto taxistaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = new Taxistas()
            {
				Id = taxistaDto.TaxistaId,
                UserName = taxistaDto.NickName,
				PasswordHash = taxistaDto.Password,
				ExisteVehiculo = taxistaDto.ExisteVehiculo,
                ExisteLicencia = taxistaDto.ExisteLicencia,
                EstadoTId = taxistaDto.EstadoTId,
                CiudadId = taxistaDto.CiudadId
            };
            contexto.Update(taxista);
            var modificado = await contexto.SaveChangesAsync() > 0;
            return modificado;
        }

        private async Task<bool> Existe(string id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .AnyAsync(e => e.Id == id);
        }

        public async Task<bool> Guardar(TaxistaDto taxistaDto)
        {
            if (!await Existe(taxistaDto.TaxistaId))
                return await Insertar(taxistaDto);
            else
                return await Modificar(taxistaDto);
        }

        public async Task<List<TaxistaDto>> Listar(Expression<Func<TaxistaDto, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas.Select(f => new TaxistaDto()
            {
                TaxistaId = f.Id,
                NickName = f.UserName,
				Password = f.PasswordHash,
				ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
                EstadoTId = f.EstadoTId,
                CiudadId = f.CiudadId
            })
            .Where(criterio)
            .ToListAsync();
        }
    }
}
