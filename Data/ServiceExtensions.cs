using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
namespace Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                return services;
        }
    }

}
