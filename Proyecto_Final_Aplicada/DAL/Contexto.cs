using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Aplicada.Models;

namespace Proyecto_Final_Aplicada.DAL
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Taxistas> Taxistas { get; set; }

    }
}
