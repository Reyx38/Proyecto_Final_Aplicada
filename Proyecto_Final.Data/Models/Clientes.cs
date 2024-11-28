using ReyAI_Trasport.Data;
using System.ComponentModel.DataAnnotations;

namespace ReyAI_Trasport.Domain.Models;

public class Clientes : ApplicationUser
{
    
    public ICollection<Viajes> Viajes { get; set; } = new List<Viajes>();

}
