using Microsoft.AspNetCore.Identity;
using ReyAI_Trasport.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Data;
// Add profile data for application users by adding properties to the ApplicationUser classr
public class ApplicationUser : IdentityUser
{
    [ForeignKey("Ciudad")]
<<<<<<< HEAD
    public int? CiudadId { get; set; }
=======
    public int CiudadId { get; set; } 
>>>>>>> 59303e9c8f4bbf28d2d85963598152e05c8c79da
    public Ciudades? Ciudad { get; set; }

}
