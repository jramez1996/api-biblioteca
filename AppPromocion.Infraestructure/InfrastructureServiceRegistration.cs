

using AppPromocion.Application.Contracts.Persistencia.Prestamo;
using AppPromocion.Infraestructure.Repository.Cronograma;
using AppPromocion.Infraestructure.Repository.Prestamo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppPromocion.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            services.AddScoped<ICommandPrestamoRepository, CommandPrestamoRepository>();

            return services;
        }
    }
}
