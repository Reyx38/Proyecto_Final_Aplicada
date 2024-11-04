using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Final.Data.Contexto;

namespace Proyecto_Final.Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<Context>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}
