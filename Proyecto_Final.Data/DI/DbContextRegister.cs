using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReyAI_Trasport.Data.Contexto;

namespace ReyAI_Trasport.Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}
