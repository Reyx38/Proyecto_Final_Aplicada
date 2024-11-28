using Microsoft.AspNetCore.Identity;
using ReyAI_Trasport.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyAI_Trasport.Data;
// Add profile data for application users by adding properties to the ApplicationUser classr
public class ApplicationUser : IdentityUser
{
    [ForeignKey("Ciudad")]
    public int CiudadId { get; set; } 
    public Ciudades? Ciudad { get; set; }

}
