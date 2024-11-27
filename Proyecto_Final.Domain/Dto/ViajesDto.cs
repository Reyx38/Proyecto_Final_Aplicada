using Proyecto_Final.Domain.Dto;

namespace ReyAI_Trasport.Domain.Dto;

public class ViajesDto
{
    public int ViajeId { get; set; }

    public string Destino { get; set; }

    public DateTime Fecha { get; set; }

    public int EstadoVId { get; set; }

    public double Precio { get; set; }

    public int personas { get; set; }

    public List<ImagenDto> Imagenes { get; set; } = new List<ImagenDto>();
    public string ClienteId { get; set; }

    public string TaxistaId { get; set; }
}
