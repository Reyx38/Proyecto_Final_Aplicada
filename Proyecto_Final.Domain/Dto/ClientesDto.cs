using Proyecto_Final.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Domain.Dto;

public class ClientesDto
{
    public int ClienteId { get; set; }

    public string NickName { get; set; }

    public string Nombres { get; set; }

    public DateTime FechaNacimiento { get; set; } 

    public string Correo { get; set; }

    public Provincias Provincia { get; set; }

    public string Password { get; set; }

    public ICollection<TaxistaDto> Favoritos { get; set; } = new List<TaxistaDto>();
}
