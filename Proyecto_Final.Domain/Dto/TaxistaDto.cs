using Proyecto_Final.Domain.Enum;

namespace Proyecto_Final.Domain.Dto;

public class TaxistaDto
{
    public int TaxistaId { get; set; }

    public string NickName { get; set; }

    public string Nombres { get; set; }

    public string Correo { get; set; }

    public bool ExisteVehiculo { get; set; }

    public bool ExisteLicencia { get; set; }
    
    public EstadosTaxistas Status { get; set; }
}
