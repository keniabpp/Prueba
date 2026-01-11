using Microsoft.Extensions.DependencyInjection;

namespace PruebaProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Los servicios se registrarán en Infrastructure
            return services;
        }
    }
}