
namespace ReyAI_Trasport.Domain.Dto;

public class TaxistaDto
{
    public string TaxistaId { get; set; }

    public string? NickName { get; set; }

    public string? Password { get; set; }

    public bool ExisteVehiculo { get; set; }

    public bool ExisteLicencia { get; set; }
    
    public int EstadoTId { get; set; }
    public int? CiudadId { get; set; }
}
