using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data.Models;
using ReyAI_Trasport.Domain.Models;

namespace ReyAI_Trasport.Data.Contexto;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{ }

	public DbSet<Clientes> Clientes { get; set; }
	public DbSet<Taxistas> Taxistas { get; set; }
	public DbSet<Viajes> Viajes { get; set; }
	public DbSet<Imagen> Imagen { get; set; }
	public DbSet<Reservaciones> Reservaciones { get; set; }
}



	
    