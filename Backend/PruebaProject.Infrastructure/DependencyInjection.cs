using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaProject.Application.Interfaces;
using PruebaProject.Domain.Interfaces;
using PruebaProject.Infrastructure.Data;
using PruebaProject.Infrastructure.Repositories;
using PruebaProject.Infrastructure.Services;

namespace PruebaProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            // Configurar Entity Framework
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Registrar repositorios
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            // Registrar servicios
            services.AddScoped<IPersonaService, PersonaServices>();

            return services;
        }
    }
}