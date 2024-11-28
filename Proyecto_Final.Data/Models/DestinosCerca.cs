using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyAI_Trasport.Data.Models;

public class DestinosCerca
{
    [Key]
    public int DestinoCercaId { get; set; }

    public string? Descripcion { get; set; }

    [ForeignKey("Ciudad")]
    public int CiudadId { get; set; }
    public Ciudades? Ciudad { get; set; }
}
