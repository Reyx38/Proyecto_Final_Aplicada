namespace ReyAI_Trasport.Domain.Dto;

public class ImagenDto
{
    public int Id { get; set; }
    public string ImagenUrl { get; set; }
    public string Alt { get; set; }
    public string? Base64 { get; set; }
	public string? Titulo { get; set; }
	public int ViajesId { get; set; }
}
