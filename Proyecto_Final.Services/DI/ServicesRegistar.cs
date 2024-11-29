using Microsoft.Extensions.DependencyInjection;
using ReyAI_Trasport.Abstracions.Interface;
using ReyAI_Trasport.Abstracions.Interfaces;
using ReyAI_Trasport.Data.DI;
using ReyAI_Trasport.Services.Services;


namespace ReyAI_Trasport.Services.DI;

public static class ServicesRegistar
{
    public static IServiceCollection RegistarService(this IServiceCollection services)
    {
        services.RegisterDbContextFactory();
        services.AddScoped<IClienteServices, ClienteServices>();
        services.AddScoped<ITaxistaServices, TaxistaServices>();
        services.AddScoped<IViajeServices, ViajeServices>();
        services.AddScoped<IReservacionesServices, ReservacionesServices>();
        services.AddScoped<ICiudadesServices, CiudadServices>();
        services.AddScoped<IViajesRapidosServices, ViajesRapidosServices>();
        services.AddScoped<IDestinosCercaServices, DestinosCercasServices>();
        services.AddScoped<IReservacionDetallesServices, ReservacionDetallesServices>();
        return services;
    }
}