using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data.Models;

namespace Proyecto_Final.Data.Contexto;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Taxistas> Taxistas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Taxistas>().HasData(new List<Taxistas>()
    {
        new Taxistas()
            {TaxistaId = 1,
            ExisteLicencia = true,
            ExisteVehiculo = true,
            NickName = "El compa",
            Nombres = "Federico Liranzo",
            FechaNacimiento = new DateTime(1985, 4, 15),
            Correo = "federicoLiranzo01@gmail.com",
            Password = "elcompa1985",
            Role = "Taxista"
            },
        new Taxistas()
        {
            TaxistaId = 2,
            ExisteLicencia = true,
            ExisteVehiculo = true,
            NickName = "Sorollo",
            Nombres = "Cesar Polanco",
            FechaNacimiento = new DateTime(1995, 7, 25),
            Correo = "cesarpolanco1@gmail.com",
            Password = "sorollo1995",
            Role = "Taxista"
        },
        new Taxistas()
        {
            TaxistaId = 3,
            ExisteLicencia = true,
            ExisteVehiculo = false,
            NickName = "El Tino",
            Nombres = "Martin Perez",
            FechaNacimiento = new DateTime(1990, 12, 5),
            Correo = "martinperez90@gmail.com",
            Password = "eltino1990",
            Role = "Taxista"

        },
        new Taxistas()
        {
            TaxistaId = 4,
            ExisteLicencia = false,
            ExisteVehiculo = true,
            NickName = "El Rápido",
            Nombres = "Juan Rodríguez",
            FechaNacimiento = new DateTime(1987, 3, 17),
            Correo = "juanrodriguez87@gmail.com",
            Password = "rapido1987",
            Role = "Taxista"
        },
        new Taxistas()
        {
            TaxistaId = 5,
            ExisteLicencia = true,
            ExisteVehiculo = true,
            NickName = "Chico",
            Nombres = "Carlos Herrera",
            FechaNacimiento = new DateTime(1992, 8, 30),
            Correo = "carlosherrera92@gmail.com",
            Password = "chico1992",
            Role = "Taxista"

        }
    });
    }
}
