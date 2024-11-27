
namespace ReyAI_Trasport.Domain.Dto;

public class ClientesDto
{
    public string ClienteId { get; set; }

    public string NickName { get; set; }

    public string Nombres { get; set; }

    public string Correo { get; set; }

    public string Password { get; set; }

    public ICollection<TaxistaDto> Favoritos { get; set; } = new List<TaxistaDto>();
}
