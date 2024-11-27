using Proyecto_Final.Domain.Dto;
using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface ICiudadesServices
{
    Task<bool> Guardar(CiudadesDto ciudadDto);
    Task<bool> Eliminar(int id);
    Task<CiudadesDto> Buscar(int id);
    Task<List<CiudadesDto>> Listar(Expression<Func<CiudadesDto, bool>> criterio);
    Task<bool> ExisteCiudad(string nombre, int id);
}
