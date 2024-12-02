using Proyecto_Final.Domain.Dto;
using ReyAI_Trasport.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Abstracions.Interfaces;

public interface IArticulosServices
{
    Task<bool> Guardar(ArticulosDto articuloDto);
    Task<bool> Eliminar(int id);
    Task<ArticulosDto> Buscar(int id);
    Task<List<ArticulosDto>> Listar(Expression<Func<ArticulosDto, bool>> criterio);
    Task<bool> ExisteArticulo(string nombre, int id);
}
