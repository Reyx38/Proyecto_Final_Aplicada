using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReyAI_Trasport.Data.Models;
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
    public DbSet<MetodosPagos> MetodosPagos { get; set; }
    public DbSet<Ciudades> Ciudades { get; set; }
    public DbSet<EstadosTaxistas> EstadosTaxistas { get; set; }
    public DbSet<DestinosCerca> DestinosCerca { get; set; }
    public DbSet<ViajesRapidos> ViajesRapidos { get; set; }
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<ReservacionDetalles> ReservacionDetalles { get; set; }
    public DbSet<Pagos> Pagos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EstadosViajes>().HasData(
        new EstadosViajes { EstadosVId = 1, Descripcion = "Pendiente" },
        new EstadosViajes { EstadosVId = 2, Descripcion = "En Curso" },
        new EstadosViajes { EstadosVId = 3, Descripcion = "Completado" },
        new EstadosViajes { EstadosVId = 4, Descripcion = "Cancelado" },
        new EstadosViajes { EstadosVId = 5, Descripcion = "Aceptada" }
        );

        builder.Entity<MetodosPagos>().HasData(
        new MetodosPagos { MetodoPagoId = 1, Descripcion = "Tarjeta de credito"}
        );

        builder.Entity<Articulos>().HasData(
            new Articulos { ArticuloId = 1, Descripcion = "Botella de agua", Costo = 18, Precio= 25, Existencia = 150 },
            new Articulos { ArticuloId = 2, Descripcion = "Jugo de naranja", Costo = 20, Precio= 35, Existencia = 150 },
            new Articulos { ArticuloId = 3, Descripcion = "Mani", Costo = 10, Precio= 30, Existencia = 150 },
            new Articulos { ArticuloId = 4, Descripcion = "FritoLay", Costo = 15, Precio= 35, Existencia = 150 },
            new Articulos { ArticuloId = 5, Descripcion = "Mentas", Costo = 2, Precio= 5, Existencia = 250 }
        );

        builder.Entity<Ciudades>().HasData(
            new Ciudades { CiudadId = 1, Nombre = "San Francisco de Macoris"},
            new Ciudades { CiudadId = 2, Nombre = "Santo Domingo"},
            new Ciudades { CiudadId = 3, Nombre = "Santigo"},
            new Ciudades { CiudadId = 4, Nombre = "Samana"},
            new Ciudades { CiudadId = 5, Nombre = "Puerto Plata"}
        );

        builder.Entity<EstadosTaxistas>().HasData(
            new EstadosTaxistas { EstadoTId = 1, Descripcion = "Disponible" },
            new EstadosTaxistas { EstadoTId = 2, Descripcion = "Ocupado" }
        );

        builder.Entity<DestinosCerca>().HasData(
            new DestinosCerca { DestinoCercaId = 1, CiudadId = 1, Descripcion = "Parque Duarte"},
            new DestinosCerca { DestinoCercaId = 2, CiudadId = 1, Descripcion = "La sirena"},
            new DestinosCerca { DestinoCercaId = 3, CiudadId = 1, Descripcion = "Supermercado Bravo"},
            new DestinosCerca { DestinoCercaId = 4, CiudadId = 1, Descripcion = "El mercado"}
        );

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "Taxista", NormalizedName = "TAXISTA" },
            new IdentityRole { Name = "Cliente", NormalizedName = "CLIENTE" }
        );

        builder.Entity<Taxistas>().HasData(
           new Taxistas
           {
               Id = "1",
               UserName = "juanperez",
               Email = "juanperez@example.com",
               PasswordHash = "hashedpassword123",
               EstadoTId = 1,
               ExisteLicencia = true,
               ExisteVehiculo = true,
               CiudadId = 1
           },
           new Taxistas
           {
               Id = "2",
               UserName = "mariagonzalez",
               Email = "mariagonzalez@example.com",
               PasswordHash = "hashedpassword456",
               EstadoTId = 1,
               ExisteLicencia = true,
               ExisteVehiculo = true,
               CiudadId = 3
           },
           new Taxistas
           {
               Id = "3",
               UserName = "carlosmendoza",
               Email = "carlosmendoza@example.com",
               PasswordHash = "hashedpassword789",
               EstadoTId = 1,
               ExisteLicencia = true,
               ExisteVehiculo = true,
               CiudadId = 2
           },
           new Taxistas
           {
               Id = "4",
               UserName = "luismartinez",
               Email = "luismartinez@example.com",
               PasswordHash = "hashedpassword101",
               EstadoTId = 1,  
               ExisteLicencia = true,
               ExisteVehiculo = true,
               CiudadId = 2
           },
           new Taxistas
           {
               Id = "5",
               UserName = "anafernandez",
               Email = "anafernandez@example.com",
               PasswordHash = "hashedpassword102",
               EstadoTId = 1,
               ExisteLicencia = true,
               ExisteVehiculo = true,
               CiudadId = 1
           }
        );
    }
}



	
    