using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Abstracions.Interface;
using Proyecto_Final.Data.Contexto;
using Proyecto_Final.Data.Models;
using Proyecto_Final.Domain.Dto;
using System.Linq;
using System.Linq.Expressions;

namespace Proyecto_Final.Services.Services
{
    public class TaxistaServices(IDbContextFactory<Context> DbFactory) : ITaxistaServices
    {
        public async Task<TaxistaDto> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = await contexto.Taxistas
           .Where(e => e.TaxistaId == id)
           .Select(p => new TaxistaDto()
           {
               TaxistaId = p.TaxistaId,
               NickName = p.NickName,
               Correo = p.Correo,
               ExisteVehiculo = p.ExisteVehiculo,
               ExisteLicencia = p.ExisteLicencia,
               Status = p.Status
           })
           .FirstOrDefaultAsync();
            return taxista ?? new TaxistaDto();
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .Where(e => e.TaxistaId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteTaxista(string nombre, int id, string correo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .AnyAsync(e => e.TaxistaId != id
                && e.NickName.ToLower().Equals(nombre.ToLower())
                && e.Correo.ToLower().Equals(correo.ToLower()));
        }

        private async Task<bool> Insertar(TaxistaDto taxistaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = new Taxistas()
            {
                TaxistaId = taxistaDto.TaxistaId,
                NickName = taxistaDto.NickName,
                Correo = taxistaDto.Correo,
                ExisteVehiculo = taxistaDto.ExisteVehiculo,
                ExisteLicencia = taxistaDto.ExisteLicencia,
                Status = taxistaDto.Status
            };
            contexto.Taxistas.Add(taxista);
            var guardo = await contexto.SaveChangesAsync() > 0;
            taxistaDto.TaxistaId = taxista.TaxistaId;
            return guardo;
        }

        private async Task<bool> Modificar(TaxistaDto taxistaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var taxista = new Taxistas()
            {
                TaxistaId = taxistaDto.TaxistaId,
                NickName = taxistaDto.NickName,
                Correo = taxistaDto.Correo,
                ExisteVehiculo = taxistaDto.ExisteVehiculo,
                ExisteLicencia = taxistaDto.ExisteLicencia,
                Status = taxistaDto.Status
            };
            contexto.Update(taxista);
            var modificado = await contexto.SaveChangesAsync() > 0;
            return modificado;
        }

        private async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Taxistas
                .AnyAsync(e => e.TaxistaId == id);
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
                TaxistaId = f.TaxistaId,
                NickName = f.NickName,
                Correo = f.Correo,
                ExisteVehiculo = f.ExisteVehiculo,
                ExisteLicencia = f.ExisteLicencia,
                Status = f.Status
            })
            .Where(criterio)
            .ToListAsync();
        }
    }
}
