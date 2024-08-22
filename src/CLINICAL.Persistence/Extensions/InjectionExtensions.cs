using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            //para evitar problemas de concurrencia y asegurar que cada solicitud HTTP
            //obtenga su propia instancia de la conexión
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}