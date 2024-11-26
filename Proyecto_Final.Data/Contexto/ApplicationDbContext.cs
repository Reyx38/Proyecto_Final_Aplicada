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
	public DbSet<EstadosViajes> EstadosViajes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EstadosViajes>().HasData(
        new EstadosViajes { EstadosVId = 1, Descripcion = "Pendiente" },
        new EstadosViajes { EstadosVId = 2, Descripcion = "En Curso" },
        new EstadosViajes { EstadosVId = 3, Descripcion = "Completado" },
        new EstadosViajes { EstadosVId = 4, Descripcion = "Cancelado" }
        );
    }
}



	
    